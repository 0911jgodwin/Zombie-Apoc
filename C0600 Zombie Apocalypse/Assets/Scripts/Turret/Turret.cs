﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRadius;
    public float rateOfFire;
    public float turnSpeed;
    
    public enum TargetMode { NEAREST, FURTHEST, WEAKEST, STRONGEST };
    public TargetMode targetMode = TargetMode.NEAREST;

    public float timer;
    public float turretHealth;

    public GameObject currentTarget;

    public List<GameObject> targetsInRange;

    // Start is called before the first frame update
    protected void Start()
    {
        targetsInRange = new List<GameObject>();
        CircleCollider2D detectionCollider = GetComponent<CircleCollider2D>();
        detectionCollider.radius = detectionRadius;
        turretHealth = 250;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Aim();
    }

    void Aim()
    {
        if (targetsInRange.Count > 0 && currentTarget != null)
        {
            //rotate towards the current target
            float targetAngle = Mathf.Atan2(
                transform.position.y - currentTarget.transform.position.y,
                transform.position.x - currentTarget.transform.position.x) * Mathf.Rad2Deg + 90f;

            float nextAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * turnSpeed);

            transform.eulerAngles = new Vector3(0f, 0f, nextAngle);

            if (IsNearTargetAngle(transform.eulerAngles.z, targetAngle, 5f))
            {
                if (timer >= rateOfFire)
                {
                    Fire(targetAngle);
                    timer = 0;
                }
            }
        }
        //else if (targetsInRange.Count == 0)
        //{
        //        transform.Rotate(anglesToRotate * Time.deltaTime);

        //        if (timer >= rateOfFire)
        //        {
        //            Fire(transform.eulerAngles.z);
        //        // crazy fire rate
        //            rateOfFire = 10;
        //            timer = 0;
        //        }
        //}
    }

    public virtual void Fire(float targetAngle)
    {
        //override with subclass fire method
    }

    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    public bool IsNearTargetAngle (float current, float target, float offset)
    {
        if (Mathf.Abs(target - current) <= offset)
            return true;
        return false;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Zombie")
        {
            if (targetsInRange.Count == 0)
            {
                currentTarget = collider.gameObject;
            }
            targetsInRange.Add(collider.gameObject);
            TargetPriority();
        }
    }


    void OnTriggerExit2D (Collider2D collider)
    {
        targetsInRange.Remove(collider.gameObject);

        if (targetsInRange.Count > 0)
        {
            TargetPriority();
        }
        else
        {
            currentTarget = null;
        }
    }

    public void OnChildTriggerEnter()
    {
        turretHealth--;
        if (turretHealth <= 0)
        {
            Debug.Log(transform.position);
            GameObject.Find("GameManager/TurretManager").GetComponent<TurretManager>().RemoveTurret(transform.position);
            Destroy(this.gameObject);
        }
    }
    

    void TargetPriority()
    {
        switch (targetMode)
        {
            case TargetMode.NEAREST:
                TargetNearest();
                break;
            case TargetMode.FURTHEST:
                TargetFurthest();
                break;
            case TargetMode.WEAKEST:
                TargetWeakest();
                break;
            case TargetMode.STRONGEST:
                TargetStrongest();
                break;
        }
        CheckTargets();
    }


    void TargetNearest()
    {
        float closestDist = 0.0f;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            if (targetsInRange[i] != null)
            {
                float dist = Vector3.Distance(transform.position, targetsInRange[i].transform.position);

                if (!currentTarget || dist < closestDist)
                {
                    currentTarget = targetsInRange[i];
                    closestDist = dist;
                }
            }
            else
            {
                targetsInRange.RemoveAt(i);
            }
        }
    }


    void TargetFurthest()
    {
        float furthestDist = 0.0f;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            if (targetsInRange[i] != null)
            {
                float dist = Vector3.Distance(transform.position, targetsInRange[i].transform.position);

                if (!currentTarget || dist > furthestDist)
                {
                    currentTarget = targetsInRange[i];
                    furthestDist = dist;
                }
            }
            else
            {
                targetsInRange.RemoveAt(i);
            }
        }
    }


    void TargetWeakest()
    {
        float lowestHealth;
        if (targetsInRange.Contains(currentTarget))
        {
            lowestHealth = currentTarget.GetComponent<Zombie>().health;
        }
        else
        {
            currentTarget = targetsInRange[0];
            lowestHealth = targetsInRange[0].GetComponent<Zombie>().health;
        }
        for (int i = 0; i < targetsInRange.Count; i++)
        {
            if (targetsInRange[i] != null)
            {
                float maxHp = targetsInRange[i].GetComponent<Zombie>().health;

                if (!currentTarget || maxHp < lowestHealth)
                {
                    lowestHealth = maxHp;
                    currentTarget = targetsInRange[i];
                }
            }
            else
            {
                targetsInRange.RemoveAt(i);
            }
        }
    }


    void TargetStrongest()
    {
        float highestHealth;

        if (targetsInRange.Contains(currentTarget))
        {
            highestHealth = currentTarget.GetComponent<Zombie>().health;
        }
        else
        {
            currentTarget = targetsInRange[0];
            highestHealth = targetsInRange[0].GetComponent<Zombie>().health;
        }

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            if (targetsInRange[i] != null)
            {
                float maxHp = targetsInRange[i].GetComponent<Zombie>().health;

                if (!currentTarget || maxHp > highestHealth)
                {
                    highestHealth = maxHp;
                    currentTarget = targetsInRange[i];
                }
            }
            else
            {
                targetsInRange.RemoveAt(i);
            }
        }
    }

    void CheckTargets()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Turret")
            {
                GameObject turretObject = collider.gameObject;
                if (turretObject != this.transform.Find("Turret Body").gameObject)
                {
                    Turret otherTurret = turretObject.transform.parent.gameObject.GetComponent<Turret>();
                    GameObject otherTarget = otherTurret.GetCurrentTarget();
                    if (otherTarget == currentTarget)
                    {
                        Retarget();
                    }
                }
            }
        }
    }

    void Retarget()
    {
        targetsInRange.Remove(currentTarget);
        GameObject temp = currentTarget;
        currentTarget = null;
        if (targetsInRange.Count > 1)
        {
            TargetPriority();
        }
        else
        {
            currentTarget = temp;
        }
        targetsInRange.Add(temp);
    }

    public void RemoveTarget(GameObject zombie)
    {
        targetsInRange.Remove(zombie);
    }
}

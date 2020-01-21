using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{	
	public float detectionRadius;
    public float rateOfFire;
    public float turnSpeed;

    public GameObject laser;
    public enum TargetMode { NEAREST, FURTHEST, WEAKEST, STRONGEST };
    public TargetMode targetMode = TargetMode.NEAREST;

    float timer;
    public float turretHealth;

    GameObject currentTarget;
    List<GameObject> targetsInRange;
    
    // Start is called before the first frame update
    void Start()
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
                    GameObject laserClone = Instantiate(laserPoint, transform.position, Quaternion.identity);
                    LaserPoint laserPointScript = laserClone.GetComponent<LaserPoint>();
        			
        			laserPointScript.Fire(currentTarget.transform);

        			timer = 0;
        		}
        	}
        }
    }
	
	bool IsNearTargetAngle(float current, float target, float offset)
    {
        if (Mathf.Abs(target - current) <= offset)
            return true;
        return false;
    }

    void OnTriggerEnter2D(Collider2D collider)
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

    void OnTriggerExit2D(Collider2D collider)
    {
        targetsInRange.Remove(collider.gameObject);

        if (targetsInRange.Count > 0)
        {
            currentTarget = targetsInRange[0];
        }
        else
        {
            currentTarget = null;
        }
        TargetPriority();
    }

    public void OnChildTriggerEnter()
    {
        turretHealth--;
        if (turretHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    /*
    * void TargetPriority()
    *
    * Author1: Olabode Bello(ob234) 
    * Author2: Alone  
    * Date: 14/1/2020
    * Course: computer Science(C0600)
    * 
    * Function: Selection control 
    * 
    * Description: allows the value of a variable to change the control flow of the targeting execution 
    *
    * Parameter: Nearest, Furthest, Weakest, Strongest -Enum
    *
    * Return: chosen targeting execution 
    */
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
    }

    void TargetNearest()
    {
        float closestDist = 0.0f;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, targetsInRange[i].transform.position);

            if (!currentTarget || dist < closestDist)
            {
                currentTarget = targetsInRange[i];
                closestDist = dist;
            }
        }
    }

    void TargetFurthest()
    {
        float furthestDist = 0.0f;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, targetsInRange[i].transform.position);

            if (!currentTarget || dist > furthestDist)
            {
                currentTarget = targetsInRange[i];
                furthestDist = dist;
            }
        }
    }

    void TargetWeakest()
    {
        int lowestHealth = currentTarget.GetComponent<Zombie>().health;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            int maxHp = targetsInRange[i].GetComponent<Zombie>().health;

            if (!currentTarget || maxHp < lowestHealth)
            {
                lowestHealth = maxHp;
                currentTarget = targetsInRange[i];
            }
        }
    }

    void TargetStrongest()
    {
        int highestHealth = currentTarget.GetComponent<Zombie>().health;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            int maxHp = targetsInRange[i].GetComponent<Zombie>().health;

            if (!currentTarget || maxHp > highestHealth)
            {
                highestHealth = maxHp;
                currentTarget = targetsInRange[i];
            }
        }
    }

}

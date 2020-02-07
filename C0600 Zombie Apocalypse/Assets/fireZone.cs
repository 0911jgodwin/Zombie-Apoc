using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireZone : MonoBehaviour
{

    public float fireArea = 10f;
    public float timer;
    public List<GameObject> targetsInRange;
    public GameObject currentTarget;
    public Hashtable burningZombies;


    // Start is called before the first frame update
    void Start()
    {
        targetsInRange = new List<GameObject>();
        burningZombies = new Hashtable();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1) { 
            DamageOverTime();
            Burn();
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Zombie"))
        {
            targetsInRange.Add(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        // might be causing little bug (might not)
        targetsInRange.Remove(collider.gameObject);       
    }



    void Burn()
    {
        Debug.Log("Hit!");
        
        timer = 0F;
   
        this.targetsInRange.ForEach(zombie =>
        {
            bool dead = zombie.GetComponent<Zombie>().Damage(2);
            if (dead)
            {
                this.targetsInRange.Remove(zombie);
                transform.parent.gameObject.GetComponent<FireTurret>().RemoveTarget(zombie);
                burningZombies.Remove(zombie);
            }
            else
            {
                if (burningZombies.Contains(zombie))
                {

                }
                burningZombies.Add(zombie, 3);
            }
        });                
    }

    void DamageOverTime()
    {
        foreach (GameObject zombie in this.burningZombies.Keys)
        {
            bool dead = zombie.GetComponent<Zombie>().Damage(1);

            if (dead)
            {
                this.targetsInRange.Remove(zombie);
                transform.parent.gameObject.GetComponent<FireTurret>().RemoveTarget(zombie);
                burningZombies.Remove(zombie);
            }
            else
            {
                //not a nice way of doing things
                burningZombies[zombie] = (int)burningZombies[zombie] - 1;
                if((int) burningZombies[zombie] == 0)
                {
                    burningZombies.Remove(zombie);
                }
            }
        }
    }


}

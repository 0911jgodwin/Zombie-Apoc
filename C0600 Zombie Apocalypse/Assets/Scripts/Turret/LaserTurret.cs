using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{	
    public GameObject laser;
	
    // Start is called before the first frame update
    new void Start()
    {
    	base.Start();
        rateOfFire = 2; 
    }
    

    public void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(LaserTurret.transform.position, lPoint.transform.forward, out hit ))
        {
            if(hit.collider.tag == "Zombie")
            {
                print ("Hit :" + hit.Collider.GameObject.Zombie);
            }
        }
    }
	
}	
    

    

    
    
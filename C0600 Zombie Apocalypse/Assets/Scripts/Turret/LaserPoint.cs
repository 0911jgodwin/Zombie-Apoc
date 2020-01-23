/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
point at which the laser originates from, and a fire method to shoot the laser

public class LaserPoint : MonoBehaviour
{

	public GameObject lPoint;

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Space))
    	{
    		Fire();
    	}
        
    }

    public void Fire()
    {
    	RaycastHit hit;

    	if(Physics.Raycast(lPoint.transform.position, lPoint.transform.forward, out hit ))
    	{
    		if(hit.collider.tag == "Zombie")
    		{
    			print ("Hit : " + hit.collider.GameObject.Zombie);
    		}
    	}
    }

}
*/
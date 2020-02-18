using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
point at which the laser originates from, and a fire method to shoot the laser
*/
    [RequireComponent(typeof(LineRenderer))]

public class LaserPoint : MonoBehaviour
{

	public GameObject lPoint;

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Space))
    	{
    		LaserTurret.Fire();
    	}
        
    }
   

}

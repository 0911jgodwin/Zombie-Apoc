/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class LightBeam : MonoBehaviour
{
	private LineRenderer lightbeam;
    // initialises the lightbeam
    void Start()
    {
    	lightbeam = GetComponent.<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	RaycastHit hit;

    	if (Physics.Raycast(transform.position, transform.forward, out hit))
    	{
    		if (hit.collider)
    		{
    			lightbeam.setPosition(1,new Vector3(0,0,hit.distance));
    		}
    	}else{
    		lightbeam..setPosition(1,new Vector3(0,0,5000));
    	}
        
    }
}
*/
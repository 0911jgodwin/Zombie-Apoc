using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

	[Header("Turret Settings")]
	public float Radius;
	public int Damage;
	public int BurnDamage;
	public int BurnLoop; // How many times do you want to take away this damage after applying the solid Damage
	public float BurnDelay; // The delay between each burn damage (0.7f is default)
	public float shootDelay;
	public float projectileSpeed;

	[Header("Info")]
	public Transform currentTarget;
	public List<Transform> visibleTargets = new List<Transform>();
	private float angle;
	public bool shooting;

	Vector3 laserScale;
   
	private GameObject laser;

	// Start is called before the first frame update
    void Start()
    { 
		laser = GameObject.Find("Laser");
		laserScale = laser.GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
		this.gameObject.GetComponent<CircleCollider2D>().radius = Radius;

		if(currentTarget == null)
		{
			GetClosestEnemy(visibleTargets);	
		}

		if(currentTarget != null)
		{
			angle = Mathf.Atan2(currentTarget.position.x, currentTarget.position.y) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler(new Vector3(0,0, -angle));
			if(!shooting){
				StartCoroutine(Shoot(shootDelay, projectileSpeed));
			}



		}
	}

	private IEnumerator Shoot(float delay, float projectileSpeed)
	{
		shooting = true;
			GameObject Clone;
			Clone = (Instantiate(laser, laser.transform.position, laser.transform.rotation)) as GameObject;
		Clone.transform.localScale = laserScale;
		Clone.GetComponent<Rigidbody2D>().isKinematic = false;
			Clone.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
		yield return new WaitForSeconds(delay);
			Destroy(Clone);

		shooting = false;
	}
		
	Transform GetClosestEnemy(List<Transform> visibleTargets)
	{
		Transform tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (Transform t in visibleTargets)
		{
			float dist = Vector3.Distance(t.position, currentPos);
			if(dist < minDist)
			{
				tMin = t;
				minDist = dist;
			}
		}
		currentTarget = tMin;
		return tMin;

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Enemy")
		{
		Debug.Log("Enemy is visible.");
		visibleTargets.Add(col.transform);

		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Enemy")
		{
			Debug.Log("Enemy is out of range.");
			visibleTargets.Remove(col.transform);
			currentTarget = null;
		}
	}
}

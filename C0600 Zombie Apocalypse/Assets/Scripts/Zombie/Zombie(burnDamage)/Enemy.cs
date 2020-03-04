using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Enemy Settings")]
	public float health;

	private bool burnEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
    }

	void TakeDamage(float damage)
	{
		health -= damage;
		for(int i = 0; i < GameObject.Find("Turret").GetComponent<TurretScript>().BurnLoop ; i++)
		{
			if(!burnEffect)
				StartCoroutine(Burn(GameObject.Find("Turret").GetComponent<TurretScript>().BurnDamage, GameObject.Find("Turret").GetComponent<TurretScript>().BurnDelay));
		}
	}

	private IEnumerator Burn(float burnDamage, float burnDelay)
	{
		burnEffect = true;

		yield return new WaitForSeconds(burnDelay);
		health -= burnDamage;

		burnEffect = false;
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Laser")
		{
			TakeDamage(GameObject.Find("Turret").GetComponent<TurretScript>().Damage);
			Destroy(col.gameObject);
		}
	}
}

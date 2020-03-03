using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Zombie : MonoBehaviour
{
    Collider2D zombieCollider;
    public int health;
    public Collider2D ZombieCollider { get { return zombieCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        zombieCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.GetKey("u"))
        {
            this.Damage(9999);
        }
    }

    public void Move(Vector2 direction)
    {
        transform.up = direction;
        transform.position += (Vector3)direction * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            Destroy(collision.gameObject);

            if (health == 0)
            {
                GameObject parentHorde = transform.parent.gameObject;
                Horde hordeScript = parentHorde.GetComponent<Horde>();
                hordeScript.removeZombie(this);
                Destroy(this.gameObject);
            }
        }
    }

    public void Damage(int incomingDamage)
    {
        health = health - incomingDamage;

        if (health <= 0)
        {
            GameObject parentHorde = transform.parent.gameObject;
            Horde hordeScript = parentHorde.GetComponent<Horde>();
            hordeScript.removeZombie(this);
            Destroy(this.gameObject);
        }
    }
}

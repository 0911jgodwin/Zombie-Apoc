using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Vector3 velocity;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetVelocityVectors(float x, float y, float magnitude)
    {
        velocity = new Vector3(x * (Time.deltaTime / 2f), y * (Time.deltaTime / 2f), 0f) * magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
        timer += Time.deltaTime;
        //Destroy the bullet if it's travelling for more than 3 seconds as it should be off screen by then.
        if (timer > 3)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            bool dead = collision.gameObject.GetComponent<Zombie>().Damage(1);

            if (dead)
            {
                transform.parent.gameObject.GetComponent<GunTurret>().RemoveTarget(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

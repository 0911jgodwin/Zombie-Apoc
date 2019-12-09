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
}

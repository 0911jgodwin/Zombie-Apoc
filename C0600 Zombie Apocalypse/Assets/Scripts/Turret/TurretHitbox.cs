using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHitbox : MonoBehaviour
{
    private Turret parent;

    void Start()
    {
        parent = transform.parent.GetComponent<Turret>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, transform.parent.rotation.z * -1.0f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Zombie")
        {
            parent.OnChildTriggerEnter();
        }
    }
}

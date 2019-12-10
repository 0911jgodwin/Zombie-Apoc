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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Zombie")
        {
            parent.OnChildTriggerEnter();
        }
    }
}

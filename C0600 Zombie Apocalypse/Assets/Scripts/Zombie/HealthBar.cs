using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Vector3 localScale;
    private Zombie zombie;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        GameObject thisZombie = transform.parent.parent.gameObject;
        zombie = thisZombie.GetComponent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = zombie.health / 5;
        transform.localScale = localScale;
    }
}

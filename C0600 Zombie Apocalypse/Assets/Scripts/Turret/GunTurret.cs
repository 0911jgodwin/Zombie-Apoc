using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : Turret
{
    new void Start()
    {
        base.Start();
        rateOfFire = 1;
    }

    public GameObject bullet;

    // Update is called once per frame
    public override void Fire(float targetAngle)
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity, this.transform);
        Bullet bulletScript = bulletClone.GetComponent<Bullet>();

        bulletScript.SetVelocityVectors(
            Mathf.Cos((targetAngle + 90f) * Mathf.Deg2Rad),
            Mathf.Sin((targetAngle + 90f) * Mathf.Deg2Rad),
            100f);
    }

}

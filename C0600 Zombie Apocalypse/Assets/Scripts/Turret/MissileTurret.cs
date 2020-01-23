using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : Turret
{
    new void Start()
    {
        base.Start();
        rateOfFire = 2;
    }

    public GameObject missile;

    // Update is called once per frame
    public override void Fire(float targetAngle)
    {
        GameObject currentTarget = GetCurrentTarget();
        GameObject missileClone = Instantiate(missile, transform.position, Quaternion.identity);
        Missile missileScript = missileClone.GetComponent<Missile>();

        missileScript.Seek(currentTarget.transform);
    }

}

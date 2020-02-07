using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurret : Turret
{
    new void Start()
    {
        base.Start();
        detectionRadius = 3;
        rateOfFire = 0;
    }

    public void RemoveTarget(GameObject zombie)
    {
        targetsInRange.Remove(zombie);
    }
}
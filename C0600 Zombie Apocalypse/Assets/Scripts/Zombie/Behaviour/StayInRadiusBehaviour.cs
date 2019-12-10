using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/StayInRadius")]
public class StayInRadiusBehaviour : HordeBehaviour
{

    public Vector2 center;
    public float radius = 15f;

    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        Vector2 centerOffset = center - (Vector2)zombie.transform.position;
        float t = centerOffset.magnitude / radius;

        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t;
    }
}

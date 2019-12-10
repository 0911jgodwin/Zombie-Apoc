using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : HordeBehaviour
{

    Vector2 currentDirection;
    public float zombieSmoothTime = 0.5f;

    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        //if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //create offset from zombie position
        cohesionMove -= (Vector2)zombie.transform.position;
        cohesionMove = Vector2.SmoothDamp(zombie.transform.up, cohesionMove, ref currentDirection, zombieSmoothTime);
        return cohesionMove;
    }
}

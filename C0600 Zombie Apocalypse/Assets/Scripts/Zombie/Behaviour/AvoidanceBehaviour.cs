using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/Avoidance")]
public class AvoidanceBehaviour : HordeBehaviour
{
    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        //if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        foreach (Transform item in context)
        {
            if (Vector2.SqrMagnitude(item.position - zombie.transform.position) < horde.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(zombie.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}

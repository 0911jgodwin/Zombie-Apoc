using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/Alignment")]
public class AlignmentBehaviour : HordeBehaviour
{
    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        //if no neighbours, maintain alignment
        if (context.Count == 0)
            return zombie.transform.up;

        //add all points together and average
        Vector2 alignmentMove = Vector2.zero;
        foreach (Transform item in context)
        {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;
        
        return alignmentMove;
    }
}

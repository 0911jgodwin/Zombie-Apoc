using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/Composite")]
public class CompositeBehaviour : HordeBehaviour
{
    public HordeBehaviour[] behaviours;
    public float[] weights;

    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        //Handles data mismatch
        if (weights.Length != behaviours.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
                return Vector2.zero;
        }

        //set up move
        Vector2 move = Vector2.zero;

        //iterate through behaviours
        for (int i= 0; i< behaviours.Length; i++)
        {
            Vector2 partialMove = behaviours[i].CalculateMove(zombie, context, horde) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights [i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Horde/Behaviour/Attack")]
public class AttackBehaviour : HordeBehaviour
{

    public float detectionRadius = 5f;

    public override Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde)
    {
        //if no enemies, maintain current alignment
        Transform enemy = GetNearbyEnemies(zombie);
        if (enemy == null)
            return zombie.transform.up;

        //move towards enemy
        Vector2 attackMove = (Vector2)(enemy.position - zombie.transform.position);

        return attackMove;
    }

    Transform GetNearbyEnemies(Zombie zombie)
    {
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(zombie.transform.position, detectionRadius);
        foreach (Collider2D c in contextColliders)
        {
            if(c.gameObject.tag == "Turret")
            {
                Transform enemy = c.transform;
                return enemy;
            }
        }
        return null;
    }
}

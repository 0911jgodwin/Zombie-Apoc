using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{

    public Zombie zombiePrefab;
    List<Zombie> zombies = new List<Zombie>();
    public HordeBehaviour behaviour;

    [Range(10, 250)]
    public int startingCount = 250;
    const float hordeDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            Zombie newZombie = Instantiate(
                zombiePrefab,
                Random.insideUnitCircle * startingCount * hordeDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newZombie.name = "Zombie " + i;
            zombies.Add(newZombie);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Zombie zombie in zombies)
        {
            List<Transform> context = GetNearbyObjects(zombie);

            Vector2 move = behaviour.CalculateMove(zombie, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            zombie.Move(move);
        }
    }

    public void removeZombie(Zombie deadZombie)
    {
        zombies.Remove(deadZombie);
    }

    List<Transform> GetNearbyObjects(Zombie zombie)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(zombie.transform.position, neighbourRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != zombie.ZombieCollider && c.gameObject.tag == "Zombie")
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}

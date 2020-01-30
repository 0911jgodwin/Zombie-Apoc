using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

    public Horde hordePrefab;
    List<Horde> hordes = new List<Horde>();
    enum SpawnPosition { LEFT, TOP, RIGHT, BOTTOM };
    float hordeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        // Spawn a wave up top
        if (Input.GetKey("i"))
        {
            CreateHorde(SpawnPosition.TOP, 250);
            //horde.Spawn(0f, 64f, 62f, 71f);
        }

        // Spawn a wave down bottom
        if (Input.GetKey("k"))
        {
            CreateHorde(SpawnPosition.BOTTOM, 250);
            //horde.Spawn(0f, 64f, -10f, -1f);
        }

        // Spawn a wave on the right
        if (Input.GetKey("l"))
        {
            CreateHorde(SpawnPosition.RIGHT, 250);
            //horde.Spawn(64f, 73f, 0f, 62f);
        }

        // Spawn a wave on the left
        if (Input.GetKey("j"))
        {
            CreateHorde(SpawnPosition.LEFT, 250);
            //horde.Spawn(-10f, -1f, 0f, 62f);
        }
    }

    private void CreateHorde(SpawnPosition position, float count)
    {
        Horde newHorde = Instantiate( hordePrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
        newHorde.name = "Horde " + hordeCounter;
        hordeCounter++;
        hordes.Add(newHorde);
        switch (position)
        {
            case SpawnPosition.LEFT:
                newHorde.Spawn(-10f, -1f, 0f, 62f, count);
                break;
            case SpawnPosition.TOP:
                newHorde.Spawn(0f, 64f, 62f, 71f, count);
                break;
            case SpawnPosition.RIGHT:
                newHorde.Spawn(64f, 73f, 0f, 62f, count);
                break;
            case SpawnPosition.BOTTOM:
                newHorde.Spawn(0f, 64f, -10f, -1f, count);
                break;
        }
    }

}

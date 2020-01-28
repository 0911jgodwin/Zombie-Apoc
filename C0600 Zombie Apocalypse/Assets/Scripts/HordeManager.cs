using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

    public Horde hordePrefab;
    List<Horde> hordes = new List<Horde>();
    float hordeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        // Spawn a wave up top
        if (Input.GetKey("i"))
        {
            Horde horde = CreateHorde();
            horde.Spawn(0f, 64f, 62f, 71f);
        }

        // Spawn a wave down bottom
        if (Input.GetKey("k"))
        {
            Horde horde = CreateHorde();
            horde.Spawn(0f, 64f, -10f, -1f);
        }

        // Spawn a wave on the right
        if (Input.GetKey("l"))
        {
            Horde horde = CreateHorde();
            horde.Spawn(64f, 73f, 0f, 62f);
        }

        // Spawn a wave on the left
        if (Input.GetKey("j"))
        {
            Horde horde = CreateHorde();
            horde.Spawn(-10f, -1f, 0f, 62f);
        }
    }

    private Horde CreateHorde()
    {
        Horde newHorde = Instantiate( hordePrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
        newHorde.name = "Horde " + hordeCounter;
        hordeCounter++;
        hordes.Add(newHorde);
        return newHorde;
    }

}

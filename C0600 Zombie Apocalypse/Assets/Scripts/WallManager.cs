using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private List<Wall> walls = new List<Wall>();

    public Wall wall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void placeWall(Vector3 location, Quaternion rotation, string type)
    {
            Wall newWall = null;
            switch (type)
            {
                case "SlotWall":
                    newWall = Instantiate(wall, location, rotation, GameObject.Find("GameManager/WallManager").transform);                    
                    break;
            }

            if (newWall != null)
            {
                //turrets.Add(newTurret);
                walls.Add(newWall);
            }
        
    }
}

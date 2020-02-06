using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{/*
    [SerializeField]
    private int width = 0;
    [SerializeField]
    private int height = 0;

    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject wall;
    private float wallWidth;

    private BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        wallWidth = wall.GetComponent<SpriteRenderer>().bounds.size.x;

        buildManager  = gameObject.AddComponent(typeof(BuildManager))  as BuildManager;

        GenerateWalls();
        GeneratePoints();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GeneratePoints()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newPoint = Instantiate(point);
                newPoint.name = "Point " + (y + (height * x) + 1);
                newPoint.transform.position = new Vector3((x * wallWidth), (y * wallWidth), 0);
                newPoint.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newPoint.transform.parent = GameObject.Find("Grid/Points").transform;
            }
        }
    }

    private void GenerateWalls()
    {
        GameObject hWalls = new GameObject(); hWalls.name = "Horizontal Walls"; hWalls.transform.parent = GameObject.Find("Grid/Walls").transform;
        GameObject vWalls = new GameObject(); vWalls.name = "Vertical Walls";   vWalls.transform.parent = GameObject.Find("Grid/Walls").transform;
        
        int count = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            { 
                if (!(x == width - 1))
                {
                    GameObject hWall = Instantiate(wall);
                    hWall.name = "hWall " + count;
                    hWall.transform.position = new Vector3(x * wallWidth, y * wallWidth, 0);
                    hWall.transform.parent = hWalls.transform;
                    hWall.GetComponent<GridWall>().SetID(count);
                    count++;
                }

                if (!(y == height - 1))
                {
                    GameObject vWall = Instantiate(wall);
                    vWall.name = "vWall " + count;
                    vWall.transform.position = new Vector3(x * wallWidth, y * wallWidth, 0);
                    vWall.transform.eulerAngles = new Vector3(0, 0, 90f);
                    vWall.transform.parent = vWalls.transform;
                    vWall.GetComponent<GridWall>().SetID(count);
                    count++;                    
                }
            }
        }
    }*/
}

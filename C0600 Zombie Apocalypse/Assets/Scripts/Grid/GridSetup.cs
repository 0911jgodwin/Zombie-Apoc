using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSetup : MonoBehaviour
{
    [SerializeField]
    private int width = 0;
    [SerializeField]
    private int height = 0;
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject wall;
    private bool pointsActive;
    private bool wallsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (!pointsActive)
            {
                DestroyChildren();
                wallsActive = false;
                GeneratePoints();
                pointsActive = true;
            }
            else
            {
                DestroyChildren();
                pointsActive = false;
            }
        }
        if (Input.GetKeyDown("l"))
        {
            if (!wallsActive)
            {
                DestroyChildren();
                pointsActive = false;
                GenerateWalls();
                wallsActive = true;
            }
            else
            {
                DestroyChildren();
                wallsActive = false;
            }
        }
    }

    void DestroyChildren()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void GeneratePoints()
    {
        GameObject points = new GameObject(); points.name = "Points"; points.transform.parent = transform;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newPoint = Instantiate(point);
                newPoint.name = "Point " + (y + (height * x) + 1);
                newPoint.transform.position = new Vector3(x * 10 + 0.625f, y * 10 + 0.625f, 0);
                GridPoint pointScript = newPoint.GetComponent<GridPoint>();
                pointScript.SetPoint(x, y);
                newPoint.transform.parent = points.transform;
            }
        }
    }

    private void GenerateWalls()
    {
        GameObject hWalls = new GameObject(); hWalls.name = "Horizontal Walls"; hWalls.transform.parent = transform;
        GameObject vWalls = new GameObject(); vWalls.name = "Vertical Walls";   vWalls.transform.parent = transform;
        
        int count = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            { 
                if (!(x == width - 1))
                {
                    GameObject hWall = Instantiate(wall);
                    hWall.name = "hWall " + count;
                    hWall.transform.position = new Vector3(x * 10, y * 10, 0);
                    hWall.transform.parent = hWalls.transform;
                    GridWall wallScript = wall.GetComponent<GridWall>();
                    wallScript.SetID(count);
                    count++;
                }

                if (!(y == height - 1))
                {
                    GameObject vWall = Instantiate(wall);
                    vWall.name = "vWall " + count;
                    vWall.transform.position = new Vector3(x * 10, y * 10, 0);
                    vWall.transform.eulerAngles = new Vector3(0, 0, 90f);
                    vWall.transform.parent = vWalls.transform;
                    GridWall wallScript = wall.GetComponent<GridWall>();
                    wallScript.SetID(count);
                    count++;                    
                }
            }
        }
    }
}

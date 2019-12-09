using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSetup : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Generate Grid on Start up.
     */
    private void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newPoint = Instantiate(point);
                newPoint.transform.position = new Vector3(x*10, y*10, 0);

                if(!(x == width - 1))
                {
                    GameObject hWall = Instantiate(wall);
                    hWall.transform.position = new Vector3(x*10 + 0.625f, y*10, 0);
                }

                if (!(y == height - 1))
                {
                    GameObject vWall = Instantiate(wall);
                    vWall.transform.position = new Vector3(x*10, y*10 + 0.625f, 0);
                    vWall.transform.eulerAngles = new Vector3(0, 0, 90f);
                }
            }
        }
    }
}

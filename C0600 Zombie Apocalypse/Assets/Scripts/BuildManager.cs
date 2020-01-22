using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private bool wallActive;
    private GameObject activeWalls;

    private bool pointActive;
    private GameObject activePoints;

    // Start is called before the first frame update
    void Start()
    {
        activeWalls  = GameObject.Find("Grid/Walls");
        activePoints = GameObject.Find("Grid/Points");

        wallActive = true;
        pointActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool WallsActive()
    {
        return wallActive;
    }

    public void ActivateWalls()
    {
        wallActive = true;
        activeWalls.SetActive(true);
    }

    public void DeactivateWalls()
    {
        wallActive = false;
        activeWalls.SetActive(false);
    }

    public bool PointsActive()
    {
        return pointActive;
    }

    public void ActivatePoints()
    {
        pointActive = true;
        activePoints.SetActive(true);
    }

    public void DeactivatePoints()
    {
        pointActive = false;
        activePoints.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject activeWalls;
    private GameObject activePoints;

    // Start is called before the first frame update
    void Start()
    {
        activeWalls  = GameObject.Find("Grid/Walls");
        activePoints = GameObject.Find("Grid/Points");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool WallsActive()
    {
        return activeWalls.activeSelf;
    }

    public void ActivateWalls()
    {
        activeWalls.SetActive(true);
    }

    public void DeactivateWalls()
    {
        activeWalls.SetActive(false);
    }

    public bool PointsActive()
    {
        return activePoints.activeSelf;
    }

    public void ActivatePoints()
    {
        activePoints.SetActive(true);
    }

    public void DeactivatePoints()
    {
        activePoints.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject gunTurret;
    private GameObject missileTurret;
    private GameObject wall;

    GridManager gridManager;

    public string lastSelected;

    // Start is called before the first frame update
    void Start()
    {
        gunTurret = GameObject.Find("Inventory/SlotGunTurret");
        missileTurret = GameObject.Find("Inventory/SlotMissileTurret");
        wall = GameObject.Find("Inventory/SlotWall");

        gridManager = GameObject.Find("GameManager/GridManager").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemClicked()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().uiSelection = gameObject.name;

        if (gameObject.name == gunTurret.name || gameObject.name == missileTurret.name)
        {
            if (!gridManager.PointsActive())
            {
                gridManager.ActivatePoints();
                if (gridManager.WallsActive()) { gridManager.DeactivateWalls(); }
            }
            else
            {
                gridManager.DeactivatePoints();
            }
        }

        if (gameObject.name == wall.name)
        {
            if (!gridManager.WallsActive())
            {
                gridManager.ActivateWalls();
                if (gridManager.PointsActive()) { gridManager.DeactivatePoints(); }
            }
            else
            {
                gridManager.DeactivateWalls();
            }
        }

        lastSelected = gameObject.name;
    }
}

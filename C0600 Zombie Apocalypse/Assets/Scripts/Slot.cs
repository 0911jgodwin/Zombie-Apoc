using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject turretSlot;
    private GameObject wallSlot;

    private BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        turretSlot = GameObject.Find("Inventory/SlotTurret");
        wallSlot = GameObject.Find("Inventory/SlotWall");

        buildManager = gameObject.AddComponent(typeof(BuildManager)) as BuildManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemClicked()
    {
        if (gameObject.name == turretSlot.name)
        {
            if (!buildManager.PointsActive())
            {
                buildManager.ActivatePoints();
                if (buildManager.WallsActive()) { buildManager.DeactivateWalls(); }
            }
            else
            {
                buildManager.DeactivatePoints();
            }
        }
        if (gameObject.name == wallSlot.name)
        {
            if (!buildManager.WallsActive())
            {
                buildManager.ActivateWalls();
                if (buildManager.PointsActive()) { buildManager.DeactivatePoints(); }
            }
            else
            {
                buildManager.DeactivateWalls();
            }
        }
    }
}

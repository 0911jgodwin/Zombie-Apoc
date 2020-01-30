using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TurretManager turretManager;
    public HordeManager hordeManager;
    public GridManager gridManager;
    // public WallManger wallManger;


    // Start is called before the first frame update
    void Start()
    {
        TurretManager turrets = Instantiate(turretManager, transform);
        turrets.name = "TurretManager";
        Instantiate(hordeManager, transform);
        GridManager grid = Instantiate(gridManager, transform);
        grid.name = "GridManager";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hitGrid = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("Grid"));

            if (hitGrid.collider != null && hitGrid.collider.gameObject.tag == "Point")
            {
                turretManager.placeTurret(
                    GameObject.Find(hitGrid.collider.gameObject.name).transform.position,
                    TurretManager.TurretType.GUN);
            }

            if (hitGrid.collider != null && hitGrid.collider.gameObject.tag == "Wall")
            {
                /*Instantiate(
                    wall,
                    GameObject.Find(hitGrid.collider.gameObject.name).transform.position,
                    GameObject.Find(hitGrid.collider.gameObject.name).transform.rotation
                );*/
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public TurretManager turretManager;
    public HordeManager hordeManager;
    public GridManager gridManager;
    public WallManager wallManager;

    public HordeManager hordes;

    public float waveCount = 1;
    public bool waveCleared = false;
    public float gameSpeed = 1f;

    public string uiSelection { get; set; } 

    // Start is called before the first frame update
    void Start()
    {
        TurretManager turrets = Instantiate(turretManager, transform);
        turrets.name = "TurretManager";
        hordes = Instantiate(hordeManager, transform);
        hordes.name = "HordeManager";
        GridManager grid = Instantiate(gridManager, transform);
        grid.name = "GridManager";
        WallManager walls = Instantiate(wallManager, transform);
        walls.name = "WallManager";

        SpawnWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickEvent();
        }

        if (waveCleared == true)
        {
            waveCleared = false;
            SpawnWave(waveCount);
        }

        if (Input.GetKeyUp("left"))
        {
            changeSpeed(false);
        }

        if (Input.GetKeyUp("right"))
        {
            changeSpeed(true);
        }
    }

    void clickEvent()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hitGrid = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("Grid"));

        if (hitGrid.collider != null && hitGrid.collider.gameObject.tag == "Point")
        {
            turretManager.placeTurret(
                GameObject.Find(hitGrid.collider.gameObject.name).transform.position,
                uiSelection);
        }

        if (hitGrid.collider != null && hitGrid.collider.gameObject.tag == "Wall")
        {
            wallManager.placeWall(
                GameObject.Find(hitGrid.collider.gameObject.name).transform.position,
                GameObject.Find(hitGrid.collider.gameObject.name).transform.rotation,
                uiSelection);
        }
    }

    void changeSpeed(bool increase)
    {
        if (increase && gameSpeed <= 4f)
        {
            gameSpeed = gameSpeed * 2;
            Time.timeScale = gameSpeed;
        }
        else if (!increase && Time.timeScale >= 0.5f)
        {
            gameSpeed = gameSpeed / 2;
            Time.timeScale = gameSpeed;
        }
    }

    public void ClearedWave()
    {
        waveCleared = true;
        waveCount++;
    }

    void SpawnWave(float waveCount)
    {
        List<int> randomRange = new List<int>();
        int randSpawn;

        if (waveCount < 10)
        {
            hordes.CreateHorde((HordeManager.SpawnPosition)Random.Range(0, 3), waveCount*10);
        }
        else if(waveCount < 25)
        {
            do
            {
                randSpawn = Random.Range(0, 3);
                if (!randomRange.Contains(randSpawn))
                {
                    hordes.CreateHorde((HordeManager.SpawnPosition)randSpawn, waveCount * 5);
                    randomRange.Add(randSpawn);
                }
            } while (randomRange.Count < 2);

        }
        else if (waveCount < 50)
        {
            do
            {
                randSpawn = Random.Range(0, 3);
                if (!randomRange.Contains(randSpawn))
                {
                    hordes.CreateHorde((HordeManager.SpawnPosition)randSpawn, waveCount * 4);
                    randomRange.Add(randSpawn);
                }
            } while (randomRange.Count < 3);
        }
        else
        {
            hordes.CreateHorde((HordeManager.SpawnPosition)0, waveCount * 3);
            hordes.CreateHorde((HordeManager.SpawnPosition)1, waveCount * 3);
            hordes.CreateHorde((HordeManager.SpawnPosition)2, waveCount * 3);
            hordes.CreateHorde((HordeManager.SpawnPosition)3, waveCount * 3);
        }
    }
}

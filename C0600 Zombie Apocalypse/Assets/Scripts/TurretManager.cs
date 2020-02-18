using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private Hashtable turrets = new Hashtable();

    public GunTurret gunTurret;
    public MissileTurret missileTurret;
    private GameObject wall;
    public float pointsOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void placeTurret(Vector3 location, string type) 
    {
        if (!turrets.ContainsKey(location))
        {
            Turret newTurret = null;
            switch (type)
            {
                case "SlotGunTurret":
                    newTurret = Instantiate(gunTurret, location, Quaternion.identity, GameObject.Find("GameManager/TurretManager").transform);
                    break;

                case "SlotMissileTurret":
                    newTurret = Instantiate(missileTurret, location, Quaternion.identity, GameObject.Find("GameManager/TurretManager").transform);
                    break;
            }

            if (newTurret != null)
            {
                //turrets.Add(newTurret);
                turrets.Add(location, newTurret);
            }
        }
    }
}

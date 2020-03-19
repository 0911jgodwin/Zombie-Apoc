using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private Dictionary<Vector3, Turret> turrets = new Dictionary<Vector3, Turret>();

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
                    Debug.Log(location);
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
        else
        {
            Debug.Log("Already got one there");
        }
    }

    public void RemoveTurret(Vector3 turretLocation)
    {
        List<Vector3> keyList = new List<Vector3>(this.turrets.Keys);

        foreach(Vector3 key in keyList)
        {
            Debug.Log(key);
        }
        Debug.Log(turrets.ContainsKey(turretLocation));
        Debug.Log(turretLocation);
        turrets.Remove(turretLocation);
    }
}

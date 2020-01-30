using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private List<Turret> turrets = new List<Turret>();
    public enum TurretType { GUN, MISSILE, LASER, FLAME };

    public GunTurret gunTurret;
    public MissileTurret missileTurret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void placeTurret(Vector3 location, TurretType type) 
    {
        Turret newTurret = null;
        switch (type)
        {
            case TurretType.GUN:
                newTurret = Instantiate(gunTurret, location, Quaternion.identity, GameObject.Find("GameManager/TurretManager").transform);
                break;

            case TurretType.MISSILE:
                newTurret = Instantiate(missileTurret, location, Quaternion.identity, transform);
                break;
        }
        if (newTurret != null)
        {
            turrets.Add(newTurret);
        }
    }
}

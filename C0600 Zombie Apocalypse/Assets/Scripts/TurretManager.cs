using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private List<Turret> turrets;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turrets != null)
        {
            foreach (Turret turret in turrets)
            {
                Debug.Log(turret);
            }
        }
    }

    public void Add(Turret turret)
    {
        turrets.Add(turret);
    }
}

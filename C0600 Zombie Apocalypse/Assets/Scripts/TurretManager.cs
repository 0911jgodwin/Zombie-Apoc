using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private List<Turret> turrets;
    private bool active = false;

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

    public void SetActive(bool boolean)
    {
        active = boolean;
    }

    public bool IsActive()
    {
        return active;
    }

    public void Add(Turret turret)
    {
        turrets.Add(turret);
    }
}

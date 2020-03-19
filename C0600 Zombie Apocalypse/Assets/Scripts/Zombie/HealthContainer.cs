using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + transform.parent.position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, transform.parent.rotation.z * -1.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int width;
    private int height;
    private float speed = 5f;
    private int boundary = 10;
    private int offset;

    // Start is called before the first frame update
    void Start()
    {
        width  = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Camera up.
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // Move Camera left.
        if (Input.GetKey("a"))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        // Move Camera down.
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }

        // Move Camera right.
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}

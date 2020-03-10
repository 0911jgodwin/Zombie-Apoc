using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int width;
    private int height;
    private float speed = 20f;
    private int offset;

    [SerializeField]
    private float leftBound = 26;
    [SerializeField]
    private float rightBound = 40;
    [SerializeField]
    private float topBound = 50;
    [SerializeField]
    private float bottomBound = 12;

    // Start is called before the first frame update
    void Start()
    {
        width  = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;

        leftBound = 26f;
        rightBound = 40f;
        topBound = 50f;
        bottomBound = 12f;
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

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftBound, rightBound), 
            Mathf.Clamp(transform.position.y, bottomBound, topBound),
            transform.position.z
        );
    }
}

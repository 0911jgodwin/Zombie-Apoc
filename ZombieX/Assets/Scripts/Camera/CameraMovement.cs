using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int width;
    private int height;
    private float speed = 20f;
    private int offset;
    private float zoomAmount;
    private float maxZoom;

    private float mapX = 70f;
    private float mapY = 65f;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float vertExtent;
    private float horzExtent;

    // Start is called before the first frame update
    void Start()
    {
        width  = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;
    }

    // Update is called once per frame
    void Update()
    {
        //Zoom camera
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().orthographicSize > 4)
        {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - 2;
            if (GetComponent<Camera>().orthographicSize <= 6)
            {
                GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("HealthBars");
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().orthographicSize < 14)
        {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + 2;
            if (GetComponent<Camera>().orthographicSize > 6)
            {
                GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("HealthBars"));
            }
        }

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

        //Used to clamp the camera to prevent it from escaping the bounds of the map
        vertExtent = GetComponent<Camera>().orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent - 5f;
        maxX = mapX - horzExtent;
        minY = vertExtent - 5f;
        maxY = mapY - vertExtent;
    }

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;
    }
}

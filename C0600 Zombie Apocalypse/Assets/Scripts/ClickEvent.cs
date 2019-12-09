﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public Turret turret;
    public Wall wall;

    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("Grid"));
            
            if (hit.collider != null && hit.collider.gameObject.tag == "Point")
            {
                Instantiate(
                    turret,
                    GameObject.Find(hit.collider.gameObject.name).transform.position,
                    Quaternion.identity
                );
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Wall")
            {
                Instantiate(
                    wall,
                    GameObject.Find(hit.collider.gameObject.name).transform.position,
                    GameObject.Find(hit.collider.gameObject.name).transform.rotation
                );
            }
        }
    }
}

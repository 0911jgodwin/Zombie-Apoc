using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWall : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;
    private int ID;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    private void Update()
    {
        
    }

    public void SetID(int ID)
    {
        this.ID = ID;
    }

    public int GetID()
    {
        return ID;
    }

    private void OnMouseEnter()
    {
        sprite.color = Color.red;
    }

    private void OnMouseExit()
    {
        sprite.color = defaultColor;
    }
}

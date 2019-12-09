using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWall : MonoBehaviour
{
    SpriteRenderer wallSprite;
    Color defaultColor;
    public int ID;
    [SerializeField]
    GameObject wall;

    public int X { get; set; }
    public int Y { get; set; }

    public GridWall(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    void Start()
    {
        wallSprite = GetComponent<SpriteRenderer>();
        defaultColor = wallSprite.color;
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
        wallSprite.color = Color.red;
    }

    private void OnMouseExit()
    {
        wallSprite.color = defaultColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    SpriteRenderer pointSprite;
    Color defaultColor;

    public int X { get; set; }
    public int Y { get; set; }

    public void SetPoint(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    void Start()
    {
        pointSprite = GetComponent<SpriteRenderer>();
        defaultColor = pointSprite.color;
    }

    private void OnMouseEnter()
    {
        pointSprite.color = Color.black;
    }

    private void OnMouseExit()
    {
        pointSprite.color = defaultColor;
    }

    public void MakeTurret()
    {
    }
}

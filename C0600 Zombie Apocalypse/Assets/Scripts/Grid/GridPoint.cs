using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    SpriteRenderer pointSprite;
    Color defaultColor;

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

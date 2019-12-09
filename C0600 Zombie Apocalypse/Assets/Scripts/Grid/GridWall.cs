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
    private bool occupied;

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

    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("Grid"));

        if (hit.collider != null && hit.collider.gameObject.tag == "Wall")
        {
            GameObject placedWall = Instantiate(wall, GameObject.Find(hit.collider.gameObject.name).transform.position, Quaternion.identity);
        }
       
    }

    private void OnMouseExit()
    {
        wallSprite.color = defaultColor;
    }
}

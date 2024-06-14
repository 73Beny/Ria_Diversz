using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
    Tilemap tileMap;
    Collider2D item2Collider; 

    private void Start()
    {
        tileMap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item2"))
        {
            item2Collider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == item2Collider)
        {
            item2Collider = null;
        }
    }

    private void OnMouseDown()
    {
        if (item2Collider != null && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePos = tileMap.WorldToCell(mousePosition);
            TileBase tile = tileMap.GetTile(tilePos);

            if (tile != null)
            {
                tileMap.SetTile(tilePos, null);
                Debug.Log("Tile destroyed at position: " + tilePos);
            }
        }
    }
}
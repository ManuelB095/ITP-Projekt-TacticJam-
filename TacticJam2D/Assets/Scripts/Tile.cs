using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isOccupied = false;
    public SpriteRenderer tileColor;
    protected GameObject occupiedBy;

    private void Start()
    {
        tileColor.color = Color.white;
        occupiedBy = null;
    }

    public void OccupyTile()
    {
        if(isOccupied)
        {
            isOccupied = false;
            tileColor.color = Color.white;
            Debug.Log("Is now unoccupied");
        }
        else if(!isOccupied)
        {
            isOccupied = true;
            tileColor.color = Color.red;
            Debug.Log("Is now occupied");
        }
    }

    public void AddUnitToTile(GameObject unitToOccupy)
    {
        if(isOccupied)
        {
            Debug.Log("Cant occupy");
        }
        else if(!isOccupied)
        {
            occupiedBy = unitToOccupy;
            Debug.Log("A unit is occupying this tile");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer tileColor;

    private bool isOccupied = false;
    protected GameObject occupiedBy;

    protected GameObject[] tileNeighbors;
    protected int row;
    protected int column;

    private void Start()
    {
        tileColor.color = Color.white;
        occupiedBy = null;
    }

    public void Initialize(int rowToSet, int colToSet)
    {
        row = rowToSet;
        column = colToSet;
    }

    public void OccupyTile()
    {
        if(!isOccupied)
        {
            isOccupied = true;
            tileColor.color = Color.red;
            Debug.Log("Is now occupied");
        } 
    }

    public void UnoccupyTile()
    {
        if (isOccupied)
        {
            isOccupied = false;
            tileColor.color = Color.white;
            Debug.Log("Is now unoccupied");
        }
    }

    public int GetRow()
    {
        return row;
    }

    public int GetColumn()
    {
        return column;
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

    public void ShowPossibleDistance(int speed)
    {
        for(int i = 1; i < speed; ++i)
        {

        }
    }
}

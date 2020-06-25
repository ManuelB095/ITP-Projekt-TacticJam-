using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer tileColor;

    private bool isOccupied = false;
    protected Unit occupiedBy;

    protected List<Tile> tileNeighbours;
    protected int row;
    protected int column;

    private void Start()
    {
        tileColor.color = Color.white;
        occupiedBy = null;
        tileNeighbours = new List<Tile>();
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

    public void AddUnitToTile(Unit unitToOccupy)
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

    public void TestPrintNeighbours()
    {
        foreach(Tile testTile in tileNeighbours)
        {
            Debug.Log("Nachbar: " + testTile.GetRow() + "." + testTile.GetColumn());
        }
    }

    public void SetTileNeighbours()
    {
        Tile neighbour = null;
        int rowOffset = 0;
        int colOffset = 0;
        TileMap daTileMapman = GameObject.FindObjectOfType<TileMap>();

        if(daTileMapman)
        {
            for (int i = 0; i < 6; ++i)
            {
                switch (i)
                {
                    case 0:
                        rowOffset = 1;
                        colOffset = 0;
                        break;

                    case 1:
                        rowOffset = 1;
                        colOffset = 1;
                        break;

                    case 2:
                        rowOffset = 0;
                        colOffset = 1;
                        break;

                    case 3:
                        rowOffset = -1;
                        colOffset = 0;
                        break;

                    case 4:
                        rowOffset = -1;
                        colOffset = -1;
                        break;

                    case 5:
                        rowOffset = 0;
                        colOffset = -1;
                        break;
                }

                neighbour = daTileMapman.GetTileFromList(GetRow() + rowOffset, GetColumn() + colOffset);
                Debug.Log(neighbour);
                if (neighbour == null)
                {
                    Debug.Log("Neighbour variable was null");
                    continue;
                }
                else
                {
                    try
                    {
                        tileNeighbours.Add(neighbour);
                        Debug.Log("Neighbour added");
                    }
                    catch(NullReferenceException ex)
                    {
                        Debug.Log("couldnt find a neighbour, error was: " + ex);
                    }
                    
                }

            }
        }
        else
        {
            Debug.Log("Tilemap couldnt be found");
        }
        
    }
}

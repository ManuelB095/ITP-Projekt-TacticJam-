﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer tileColor;

    private bool isOccupied = false;
    private bool isShowingDistance = false;
    private bool isShowingAttackRange = false;
    protected Unit occupiedBy;

    protected List<Tile> tileNeighbours;
    protected int row;
    protected int column;
    
    private void Awake()
    {
        tileNeighbours = new List<Tile>();
        tileColor.color = Color.white;
        occupiedBy = null;
    }

    private void Start()
    {
        
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
            tileColor.color = Color.yellow;
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

    public bool IsShowingDistance()
    {
        return isShowingDistance;
    }

    public bool IsShowingAttackRange()
    {
        return isShowingAttackRange;
    }

    public List<Tile> GetNeighbourList()
    {
        return this.tileNeighbours;
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

    public void ShowPossibleDistance(int speed, int attackRange)
    {
        foreach (Tile neighbours in tileNeighbours)
        {
            neighbours.ColorPossibleDistance();
        }
        if (speed == 1)
        {
            return;
        }

        List<Tile> coloredTiles = new List<Tile>();
        foreach (Tile neighbours in tileNeighbours)
        {
            coloredTiles.Add(neighbours);
        }

        for (int i = 1; i < speed; ++i)
        {
            List<Tile> temporaryList = new List<Tile>();
            foreach(Tile colorNeighbour in coloredTiles)
            {
                foreach(Tile newColoredNeighbour in colorNeighbour.GetNeighbourList())
                {
                    if (newColoredNeighbour.IsShowingDistance())
                    { }
                    else
                    {
                        newColoredNeighbour.ColorPossibleDistance();
                        temporaryList.Add(newColoredNeighbour);
                    }
                }
            }
            foreach(Tile temporaryTile in temporaryList)
            {
                coloredTiles.Add(temporaryTile);
            }
        }

        for (int i = 0; i < attackRange; ++i)
        {
            List<Tile> temporaryList = new List<Tile>();
            foreach (Tile colorNeighbour in coloredTiles)
            {
                foreach (Tile newColoredNeighbour in colorNeighbour.GetNeighbourList())
                {
                    if (newColoredNeighbour.IsShowingDistance() || newColoredNeighbour.IsShowingAttackRange())
                    { }
                    else
                    {
                        newColoredNeighbour.ColorPossibleAttackRange();
                        temporaryList.Add(newColoredNeighbour);
                    }
                }
            }
            foreach (Tile temporaryTile in temporaryList)
            {
                coloredTiles.Add(temporaryTile);
            }
        }

    }

    public void ColorPossibleDistance()
    {
        this.tileColor.color = Color.blue;
        this.isShowingDistance = true;
    }

    public void ColorPossibleAttackRange()
    {
        this.tileColor.color = Color.red;
        this.isShowingAttackRange = true;
    }

    public void UncolorTile()
    {
        this.tileColor.color = Color.white;
        this.isShowingDistance = false;
        this.isShowingAttackRange = false;
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
                if (neighbour == null)
                {
                    continue;
                }
                else
                {
                    tileNeighbours.Add(neighbour);
                    Debug.Log("Neighbour added");
                }

            }
        }
        else
        {
            Debug.Log("Tilemap couldnt be found");
        }
        
    }
}

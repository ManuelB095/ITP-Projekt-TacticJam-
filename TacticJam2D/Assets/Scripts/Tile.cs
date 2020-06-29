using System;
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

    public void Initialize(int rowToSet, int colToSet)
    {
        row = rowToSet;
        column = colToSet;
    }

    //Getters
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
        return tileNeighbours;
    }

    public Unit IsOccupiedByUnit()
    {
        return occupiedBy;
    }

    //Unit Placement
    public void OccupyTile(Unit unitToOccupy)
    {
        if(!isOccupied)
        {
            occupiedBy = unitToOccupy;
            isOccupied = true;
            tileColor.color = Color.yellow;
            Debug.Log("Is now occupied");
        } 
    }

    public void UnoccupyTile()
    {
        if (isOccupied)
        {
            occupiedBy = null;
            isOccupied = false;
            tileColor.color = Color.white;
            Debug.Log("Is now unoccupied");
        }
    }

    public void ColorTileForTurn(int color)
    {
        switch(color)
        {
            case 1:
                tileColor.color = Color.cyan;
                break;
            case 2:
                tileColor.color = Color.green;
                break;
            case 3:
                tileColor.color = Color.yellow;
                break;
            case 4:
                tileColor.color = Color.yellow;
                break;
            default:
                tileColor.color = Color.white;
                break;
        }
        
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

    //Coloring Tiles (Ranges of Units)
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
        Color newColor = new Color(0.2f, 0.5f, 1.0f, 0.9f);
        this.tileColor.color = newColor;
        this.isShowingDistance = true;
    }

    public void ColorPossibleAttackRange()
    {
        Color newColor = new Color(1.0f, 0.2f, 0.4f, 0.9f);
        this.tileColor.color = newColor;
        this.isShowingAttackRange = true;
    }

    public void UncolorTile()
    {
        //if occupied, check if that team is active, then if yes color cyan, if no color yellow
        if(occupiedBy != null)
        {
            if(GameObject.FindObjectOfType<GameHandler>().GetActiveTeam() == occupiedBy.GetUnitsTeam())
            {
                switch(occupiedBy.GetUnitState())
                {
                    case 1:
                        this.tileColor.color = Color.cyan;
                        this.isShowingDistance = false;
                        this.isShowingAttackRange = false;
                        return;
                    case 2:
                        tileColor.color = Color.green;
                        this.isShowingDistance = false;
                        this.isShowingAttackRange = false;
                        return;
                    case 3:
                        tileColor.color = Color.yellow;
                        this.isShowingDistance = false;
                        this.isShowingAttackRange = false;
                        return;

                }
            }
            else
            {
                this.tileColor.color = Color.yellow;
                this.isShowingDistance = false;
                this.isShowingAttackRange = false;
                return;
            }
        }
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

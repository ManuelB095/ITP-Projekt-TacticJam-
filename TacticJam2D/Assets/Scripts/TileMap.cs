using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    //Prefabs
    public GameObject tile;
    public GameObject playerUnitBlue;
    public GameObject playerUnitRed;

    //Tilemap variables
    private int height;
    private int length;
    private List<Tile> tileList;
    private List<Unit> unitList;

    public TileMap()
    {
        this.height = 7;
        this.length = 9;
    }

    void Start()
    {
        tileList = new List<Tile>();
        unitList = new List<Unit>();

        GenerateMap1();
        AddUnitToMap(0, 50);
        GameObject.FindObjectOfType<GameHandler>().SetActiveTeam((int)Team.teamOne);
    }

    //Getter
    private int GetHeight()
    {
        return this.height;
    }

    private int GetLength()
    {
        return this.length;
    }

    private Vector2 GetTileVector(int tileInList)
    {
        float x = tileList[tileInList].transform.position.x;
        float y = tileList[tileInList].transform.position.y + 0.2f;

        Vector2 vec = new Vector2(x, y);
        return vec;
    }

    public Tile GetTileFromList(int row, int column)
    {
        Tile tileToLookFor = tileList.Find(ourObject => ourObject.GetRow() == row && ourObject.GetColumn() == column);
        if (tileToLookFor)
        {
            return tileToLookFor;
        }
        else
        {
            return null;
        }
    }

    //Map Generators
    private void GenerateMapTest()
    {
        for (int x = 0; x < GetHeight(); ++x)
        {
            for (int y = 0; y < GetLength(); ++y)
            {
                GameObject newTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                newTile.GetComponent<Tile>().Initialize(x + 1, y + 1);
                tileList.Add(newTile.GetComponent<Tile>());
            }
        }
    }

    private void GenerateMap1()
    {
        Vector2 startPosition = new Vector2(-3f, -3f);
        int rowOffset = 0;
        float offset = 0f;

        for(int x = 0; x < GetHeight(); ++x)
        {
            for(int y = 0; y < GetLength(); ++y)
            {
                Vector2 newTilePosition = new Vector2(startPosition.x + (y*1.44f) - offset, startPosition.y + (x*1.08f));   //y*0,96 , x*0,72
                GameObject newTile = Instantiate(tile, newTilePosition, Quaternion.identity);
                newTile.GetComponent<Tile>().Initialize(x + 1, y + 1 + rowOffset);
                tileList.Add(newTile.GetComponent<Tile>());

                if ((x == 0 || x == 6) && y == 5)
                { 
                    break;
                }
                if((x == 1 || x == 5) && y == 6)
                { 
                    break;
                }
                if((x == 2 || x == 4) && y == 7)
                {
                    break;
                }
            }
            if(x >= 3)
            {
                ++rowOffset;
                offset -= 0.72f;   //0,48 original
            }
            else
            {
                offset += 0.72f;
            } 
        }
        foreach (Tile tile in tileList)
        {
            tile.SetTileNeighbours();
        }
    }

    //Unit Handling
    //This is a test function and needs rewriting
    private void AddUnitToMap(int tileNumber, int tileEnemy)
    {
        GameObject newUnitBlue = Instantiate(playerUnitBlue, GetTileVector(tileNumber), Quaternion.identity);
        GameObject.FindObjectOfType<GameHandler>().AddUnitToList(newUnitBlue.GetComponent<Unit>(), 1);
        Tile tileToAddTo = tileList[tileNumber];
        tileToAddTo.AddUnitToTile(newUnitBlue.GetComponent<Unit>());
        newUnitBlue.GetComponent<Unit>().Initialize(tileToAddTo, 1, 4);
        tileToAddTo.OccupyTile(newUnitBlue.GetComponent<Unit>());

        GameObject newUnitRed = Instantiate(playerUnitRed, GetTileVector(tileEnemy), Quaternion.identity);
        GameObject.FindObjectOfType<GameHandler>().AddUnitToList(newUnitRed.GetComponent<Unit>(), 2);
        Tile tileToAddTo2 = tileList[tileEnemy];
        tileToAddTo2.AddUnitToTile(newUnitRed.GetComponent<Unit>());
        newUnitRed.GetComponent<Unit>().Initialize(tileToAddTo2, 2, 4);
        tileToAddTo2.OccupyTile(newUnitRed.GetComponent<Unit>());
    }

    
    public void UnshowPossibleDistance()
    {
        foreach(Tile tile in tileList)
        {
            if(tile.IsShowingAttackRange() || tile.IsShowingDistance())
            {
                tile.UncolorTile();
            }
        }
    }
}

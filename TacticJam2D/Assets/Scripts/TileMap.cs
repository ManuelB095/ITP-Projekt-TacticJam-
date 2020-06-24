using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject tile;
    public GameObject unit;
    private int height;
    private int length;
    private List<GameObject> tileList;
    private List<GameObject> unitList;

    public TileMap()
    {
        this.height = 7;
        this.length = 9;
    }

    void Start()
    {
        tileList = new List<GameObject>();
        unitList = new List<GameObject>();

        GenerateMap1();
        AddUnitToMap(0);
    }

    private void GenerateMapTest()
    {
        for (int x = 0; x < GetHeight(); ++x)
        {
            for (int y = 0; y < GetLength(); ++y)
            {
                GameObject newTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                newTile.GetComponent<Tile>().Initialize(x + 1, y + 1);
                tileList.Add(newTile);
            }
        }
    }

    private void GenerateMap1()
    {
        Vector2 startPosition = new Vector2(-3f, -2f);
        int rowOffset = 0;
        float offset = 0f;

        for(int x = 0; x < GetHeight(); ++x)
        {
            for(int y = 0; y < GetLength(); ++y)
            {
                Vector2 newTilePosition = new Vector2(startPosition.x + y - offset, startPosition.y + (x*0.75f));
                GameObject newTile = Instantiate(tile, newTilePosition, Quaternion.identity);
                newTile.GetComponent<Tile>().Initialize(x + 1, y + 1 + rowOffset);
                tileList.Add(newTile);

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
                offset -= 0.5f;
            }
            else
            {
                offset += 0.5f;
            }
        }
    }

    private void AddUnitToMap(int tileNumber)
    {
        GameObject newUnit = Instantiate(unit, GetTileVector(tileNumber), Quaternion.identity);
        unitList.Add(newUnit);
        GameObject tileToAddTo = tileList[tileNumber];
        tileToAddTo.GetComponent<Tile>().AddUnitToTile(newUnit);
        tileToAddTo.GetComponent<Tile>().OccupyTile();
    }

    public GameObject ReturnTile(int x, int y)
    {
        GameObject tileToLookFor = tileList.Find(ourObject => ourObject.transform.position.x == x && ourObject.transform.position.y == y);
        return tileToLookFor;
    }

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

}

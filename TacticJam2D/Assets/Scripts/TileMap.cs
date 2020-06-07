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
        this.height = 6;
        this.length = 4;
    }

    void Start()
    {
        tileList = new List<GameObject>();
        unitList = new List<GameObject>();

        for(int x = 0; x < GetHeight(); ++x)
        {
            for(int y = 0; y < GetLength(); ++y)
            {
                tileList.Add(Instantiate(tile, new Vector2(x,y), Quaternion.identity));
            }
        }
        AddUnitToMap(0);
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

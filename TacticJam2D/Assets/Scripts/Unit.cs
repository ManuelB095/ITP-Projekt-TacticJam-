using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //Cool variables here



    private void Start()
    {
        //Initialize your shit here
    }

    //Cool Methods here

    public void MoveUnit(Transform newLocation, GameObject tileToMoveTo)
    {
        float x, y;
        x = newLocation.position.x;
        y = newLocation.position.y + 0.2f;

        this.transform.position = new Vector2(x, y);
        tileToMoveTo.GetComponent<Tile>().OccupyTile();

    }

}

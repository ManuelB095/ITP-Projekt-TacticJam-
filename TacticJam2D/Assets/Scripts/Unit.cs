using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GameObject tileOccupiedBy;
    int speed;
    int attackRange;

    private void Start()
    {
        tileOccupiedBy = null;
        speed = 2;
        attackRange = 1;
    }

    public void MoveUnit(Transform newLocation, GameObject tileToMoveTo)
    {
        if(tileOccupiedBy != null)
        {
            tileOccupiedBy.GetComponent<Tile>().UnoccupyTile();
        }

        tileOccupiedBy = tileToMoveTo;
        float x, y;
        x = newLocation.position.x;
        y = newLocation.position.y + 0.2f;

        this.transform.position = new Vector2(x, y);
        tileToMoveTo.GetComponent<Tile>().OccupyTile();
    }

    public void ShowPossibleDistance()
    {
        if (tileOccupiedBy != null)
        {
            tileOccupiedBy.GetComponent<Tile>().ShowPossibleDistance(speed);
        }
    }
}



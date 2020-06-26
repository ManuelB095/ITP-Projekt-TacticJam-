using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Tile tileOccupiedBy;
    int speed;
    int attackRange;

    private void Awake()
    {
        tileOccupiedBy = null;
        speed = 2;
        attackRange = 1;
    }

    public void Initialize(Tile tileToOccupy)
    {
        tileOccupiedBy = tileToOccupy;
    }

    public void MoveUnit(Transform newLocation, Tile tileToMoveTo)
    {
        if(tileOccupiedBy != null)
        {
            tileOccupiedBy.UnoccupyTile();
        }

        tileOccupiedBy = tileToMoveTo;
        float x, y;
        x = newLocation.position.x;
        y = newLocation.position.y + 0.2f;

        this.transform.position = new Vector2(x, y);
        tileToMoveTo.OccupyTile();
    }

    public void ShowPossibleDistance()
    {
        if (tileOccupiedBy != null)
        {
            tileOccupiedBy.ShowPossibleDistance(speed, attackRange);
        }
    }
}



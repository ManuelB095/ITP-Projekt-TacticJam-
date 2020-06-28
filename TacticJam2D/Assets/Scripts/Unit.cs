using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Tile tileOccupiedBy;
    public Healthbar healthbar;
    private Team isOnTeam;
    private State unitState;

    int maxHealth;
    int currentHealth;
    int attackPower;
    int speed;
    int attackRange;

    enum State
    {
        myTurn = 1,
        myTurnMoved = 2,
        myTurnDone = 3,
        notMyTurn = 4
    }

    private void Awake()
    {
        maxHealth = 30;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        tileOccupiedBy = null;
        speed = 2;
        attackRange = 1;
        attackPower = 8;
    }

    public void Initialize(Tile tileToOccupy, int team, int state)
    {
        tileOccupiedBy = tileToOccupy;
        isOnTeam = (Team)team;
        unitState = (State)state;
    }

    //Moving functions
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
        tileToMoveTo.OccupyTile(this);
    }

    public void ShowPossibleDistance()
    {
        if (tileOccupiedBy != null)
        {
            tileOccupiedBy.ShowPossibleDistance(speed, attackRange);
        }
    }

    //Funktion derzeit nur für Range 1, benötigt Anpassung für höhere Attackranges
    public bool HasSelectedEnemyInRange(Unit enemy)
    {
        List<Tile> neighbourList = tileOccupiedBy.GetNeighbourList();
        foreach(Tile tile in neighbourList)
        {
            if(tile.IsOccupiedByUnit() == enemy)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasEnemyInRange()
    {
        List<Tile> neighbourList = tileOccupiedBy.GetNeighbourList();
        foreach (Tile tile in neighbourList)
        {
            if (tile.IsOccupiedByUnit() != null)
            {
                return true;
            }
        }
        return false;
    }

    //Getter und Setter
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public int GetUnitState()
    {
        return (int)unitState;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetUnitsTeam()
    {
        return (int)isOnTeam;
    }

    public void SetUnitState(int state)
    {
        unitState = (State)state;
        tileOccupiedBy.ColorTileForTurn(state);
    }
}



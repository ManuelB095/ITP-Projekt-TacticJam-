using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    int[] playerCharacters = new int[3];
    int[] enemyCharacters = new int[3];

    int teamOneCharacterCount;
    int teamTwoCharacterCount;
    private Team activeTeam;

    private List<Unit> teamOneUnits;
    private List<Unit> teamTwoUnits;

    private void Awake()
    {
        teamOneUnits = new List<Unit>();
        teamTwoUnits = new List<Unit>();
        activeTeam = Team.teamOne;
    }

    /*void Start()
    {
        AudioManager audioMngr = FindObjectOfType<AudioManager>();
        audioMngr.StopPlaying();
        audioMngr.Play("BattleTheme1");

        for (int i = 0; i < 3; i++)
        {
            playerCharacters[i] = GameObject.Find("GameData").GetComponent<GameData>().getunitsone(i);
            enemyCharacters[i] = GameObject.Find("GameData").GetComponent<GameData>().getunitstwo(i);
            print("Spieler eins " + playerCharacters[i]);
            print("Spieler zwei " + enemyCharacters[i]);
        }
    }*/

    public void SetActiveTeam(int team)
    {
        activeTeam = (Team)team;
        if(activeTeam == Team.teamOne)
        {
            foreach (Unit unit in teamOneUnits)
            {
                unit.SetUnitState(1);
            }
            foreach(Unit unit in teamTwoUnits)
            {
                unit.SetUnitState(4);
            }
        }
        else if(activeTeam == Team.teamTwo)
        {
            foreach (Unit unit in teamTwoUnits)
            {
                unit.SetUnitState(1);
            }
            foreach (Unit unit in teamOneUnits)
            {
                unit.SetUnitState(4);
            }
        }
        
    }

    public void CheckForTurnEnd()
    {
        if (activeTeam == Team.teamOne)
        {
            bool endTurn = true;
            foreach(Unit unit in teamOneUnits)
            {
                if(unit.GetUnitState() != 3)
                {
                    endTurn = false;
                }
            }
            if(endTurn)
            {
                SetActiveTeam((int)Team.teamTwo);
            }
        }
        else if(activeTeam == Team.teamTwo)
        {
            bool endTurn = true;
            foreach (Unit unit in teamTwoUnits)
            {
                if (unit.GetUnitState() != 3)
                {
                    endTurn = false;
                }
            }
            if (endTurn)
            {
                SetActiveTeam((int)Team.teamOne);
            }
        }
    }

    public int GetActiveTeam()
    {
        return (int)activeTeam;
    }
    
    public void AddUnitToList(Unit unitToAdd, int team)
    {
        if(team == 1)
        {
            teamOneUnits.Add(unitToAdd);
            return;
        }
        else if(team == 2)
        {
            teamTwoUnits.Add(unitToAdd);
            return;
        }
    }
}

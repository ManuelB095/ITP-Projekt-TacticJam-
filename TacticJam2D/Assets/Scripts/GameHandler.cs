using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameHandler : MonoBehaviour
{
    int[] playerCharacters = new int[3];
    int[] enemyCharacters = new int[3];

    int teamOneCharacterCount;
    int teamTwoCharacterCount;
    private Team activeTeam;

    private List<Unit> teamOneUnits;
    private List<Unit> teamTwoUnits;

    //UI Stuff
    public Text playerOneTurn;
    public Text playerTwoTurn;
    public Text victoryText;
    public Button endTurnButton;
    public Button endGameButton;
    

    private void Awake()
    {
        teamOneUnits = new List<Unit>();
        teamTwoUnits = new List<Unit>();
        activeTeam = Team.teamOne;
        playerTwoTurn.enabled = false;
        victoryText.enabled = false;
        Button endTurn = endTurnButton.GetComponent<Button>();
        endTurn.onClick.AddListener(EndTurnFunction);
        Button endGame = endGameButton.GetComponent<Button>();
        endGame.onClick.AddListener(FinalizeGame);
        endGameButton.image.enabled = false;
        endGameButton.enabled = false;
    }

    void Start()
    {
        try
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
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("Audio manager could not be found, error message was: " + ex);
        }
        
    }

    public void EndTurnFunction()
    {
        GameObject.FindObjectOfType<MouseManager>().UnsetMouseObjects();
        switch(activeTeam)
        {
            case Team.teamOne:
                SetActiveTeam((int)Team.teamTwo);
                break;
            case Team.teamTwo:
                SetActiveTeam((int)Team.teamOne);
                break;
        }
    }

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
            playerOneTurn.enabled = true;
            playerTwoTurn.enabled = false;
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
            playerOneTurn.enabled = false;
            playerTwoTurn.enabled = true;
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

    public void CheckGameEnd(Team teamToCheckFor)
    {
        bool gameOver = true;
        switch(teamToCheckFor)
        {
            case Team.teamOne:
                foreach(Unit unit in teamOneUnits)
                {
                    if(unit.GetAliveStatus())
                    {
                        gameOver = false;
                    }
                }
                if(gameOver)
                {
                    EndGame(teamToCheckFor);
                }
                break;

            case Team.teamTwo:
                foreach (Unit unit in teamTwoUnits)
                {
                    if (unit.GetAliveStatus())
                    {
                        gameOver = false;
                    }
                }
                if (gameOver)
                {
                    EndGame(teamToCheckFor);
                }
                break;
        }
    }

    private void EndGame(Team teamThatLost)
    {
        //do thingy for winning team
        endGameButton.image.enabled = true;
        endGameButton.enabled = true;
        victoryText.enabled = true;
        if(teamThatLost == Team.teamOne)
        {
            victoryText.text = "Player 2 Wins!";
        }
        if (teamThatLost == Team.teamTwo)
        {
            victoryText.text = "Player 1 Wins!";
        }
        playerOneTurn.enabled = false;
        playerTwoTurn.enabled = false;
        endTurnButton.image.enabled = false;
        endTurnButton.enabled = false;
    }

    private void FinalizeGame()
    {
        //Send players back to main menu
        Debug.Log("grats");
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

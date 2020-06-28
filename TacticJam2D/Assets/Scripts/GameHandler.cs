using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    int[] playerCharacters = new int[3];
    int[] enemyCharacters = new int[3];

    int teamOneCharacters;
    int teamTwoCharacters;
    private Team activeTeam;

    private List<Unit> teamOneUnits;
    private List<Unit> teamTwoUnits;

    private void Awake()
    {
        teamOneUnits = new List<Unit>();
        teamTwoUnits = new List<Unit>();
        activeTeam = Team.teamOne;
    }

    void Start()
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

    public void SetActiveTeam(int team)
    {
        activeTeam = (Team)team;
    }

    public int GetActiveTeam()
    {
        return (int)activeTeam;
    }
    
}

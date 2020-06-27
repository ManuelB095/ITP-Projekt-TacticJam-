using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    int[] playerCharacters = new int[3];
    int[] enemyCharacters = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            playerCharacters[i] = GameObject.Find("GameData").GetComponent<GameData>().getunitsone(i);
            enemyCharacters[i] = GameObject.Find("GameData").GetComponent<GameData>().getunitstwo(i);
            print("Spieler eins " + playerCharacters[i]);
            print("Spieler zwei " + enemyCharacters[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

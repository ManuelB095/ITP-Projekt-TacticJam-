using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
  public void Start()
    {
        AudioManager audioMngr = FindObjectOfType<AudioManager>();
        audioMngr.StopPlaying();
        audioMngr.Play("MenuTheme1");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit !");
        Application.Quit();
    }


}

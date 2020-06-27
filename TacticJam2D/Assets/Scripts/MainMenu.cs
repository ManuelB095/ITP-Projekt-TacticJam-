using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text textfeldone;
    public Text textfeldtwo;
    public Text textfeldthree;
    public int unitone = 0;
    public int unittwo = 0;
    public int unitthree = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit !");
        Application.Quit();
    }




    public void ChangeUniteRight(int unit)
    {
        if (unit == 0)
        {
            unitone++;
            if (unitone == 3)
            {
                unitone = 0;

            }
            unitname(unitone, textfeldone);
        }
        else if (unit == 1)
        {
            unittwo++;
            if (unittwo == 3)
            {
                unittwo = 0;
            }
            unitname(unittwo, textfeldtwo);
        }
        else if (unit == 2)
        {
            unitthree++;
            if (unitthree == 3)
            {
                unitthree = 0;
            }
            unitname(unitthree, textfeldthree);
        }
    }

    public void ChangeUniteLeft(int unit)
    {
        if (unit == 0)
        {
            unitone--;
            if (unitone == -1)
            {
                unitone = 2;
            }
            unitname(unitone, textfeldone);
        }
        else if (unit == 1)
        {
            unittwo--;
            if (unittwo == -1)
            {
                unittwo = 2;
            }
            unitname(unittwo, textfeldtwo);
        }
        else if (unit == 2)
        {
            unitthree--;
            if (unitthree == -1)
            {
                unitthree = 2;
            }
            unitname(unitthree, textfeldthree);
        }
    }

    private void unitname(int i, Text feld)
    {
        if (i == 0)
        {
            feld.text = "Swordsman";
        }
        else if (i == 1)
        {
            feld.text = "Archer";
        }
        else if (i == 2)
        {
            feld.text = "Barrier";
        }
    }

}

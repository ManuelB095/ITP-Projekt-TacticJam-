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

    public Sprite swordsman;
    public Sprite superSwordsman;
    public Sprite evilSwordsman;

    public Image imageOne;
    public Image imageTwo;
    public Image imageThree;

    public int unitone = 0;
    public int unittwo = 0;
    public int unitthree = 0;

    public void StartGame()
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
            unitImage(unitone, imageOne);
        }
        else if (unit == 1)
        {
            unittwo++;
            if (unittwo == 3)
            {
                unittwo = 0;
            }
            unitname(unittwo, textfeldtwo);
            unitImage(unittwo, imageTwo);

        }
        else if (unit == 2)
        {
            unitthree++;
            if (unitthree == 3)
            {
                unitthree = 0;
            }
            unitname(unitthree, textfeldthree);
            unitImage(unitthree, imageThree);

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
            unitImage(unitone, imageOne);
        }
        else if (unit == 1)
        {
            unittwo--;
            if (unittwo == -1)
            {
                unittwo = 2;
            }
            unitname(unittwo, textfeldtwo);
            unitImage(unittwo, imageTwo);
        }
        else if (unit == 2)
        {
            unitthree--;
            if (unitthree == -1)
            {
                unitthree = 2;
            }
            unitname(unitthree, textfeldthree);
            unitImage(unitthree, imageThree);
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

    private void unitImage(int i, Image img)
    {
        img = img.GetComponent<Image>();

        if (i == 0)
        {
            img.sprite = swordsman;
        }
        else if (i == 1)
        {
            img.sprite = superSwordsman;
        }
        else if (i == 2)
        {
            img.sprite = evilSwordsman;
        }
    }

}

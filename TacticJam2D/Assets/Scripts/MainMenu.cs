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



    //------------------Press right on Unit selection------------------
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unitone);
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unittwo);
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unitthree);
            unitImage(unitthree, imageThree);

        }




        else if (unit == 3)
        {
            unitone++;
            if (unitone == 3)
            {
                unitone = 0;

            }
            unitname(unitone, textfeldone);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unitone);
            unitImage(unitone, imageOne);
        }
        else if (unit == 4)
        {
            unittwo++;
            if (unittwo == 3)
            {
                unittwo = 0;
            }
            unitname(unittwo, textfeldtwo);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unittwo);
            unitImage(unittwo, imageTwo);

        }
        else if (unit == 5)
        {
            unitthree++;
            if (unitthree == 3)
            {
                unitthree = 0;
            }
            unitname(unitthree, textfeldthree);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unitthree);
            unitImage(unitthree, imageThree);

        }






    }
    //----------------Press left on Unit selection-----------------------
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unitone);
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unittwo);
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
            GameObject.Find("GameData").GetComponent<GameData>().setunitsone(unit, unitthree);
            unitImage(unitthree, imageThree);
        }

        else if (unit == 3)
        {
            unitone--;
            if (unitone == -1)
            {
                unitone = 2;
            }
            unitname(unitone, textfeldone);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unitone);
            unitImage(unitone, imageOne);
        }
        else if (unit == 4)
        {
            unittwo--;
            if (unittwo == -1)
            {
                unittwo = 2;
            }
            unitname(unittwo, textfeldtwo);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unittwo);
            unitImage(unittwo, imageTwo);
        }
        else if (unit == 5)
        {
            unitthree--;
            if (unitthree == -1)
            {
                unitthree = 2;
            }
            unitname(unitthree, textfeldthree);
            GameObject.Find("GameData").GetComponent<GameData>().setunitstwo(unit - 3, unitthree);
            unitImage(unitthree, imageThree);
        }
    }


    //--------------------Change text feld for unit-------------------------
    private void unitname(int i, Text feld)
    {
        if (i == 0)
        {
            feld.text = "Swordsman";
        }
        else if (i == 1)
        {
            feld.text = "superSwordsman";
        }
        else if (i == 2)
        {
            feld.text = "evilSwordsman";
        }
    }

    //------------------change image for unit------------------------
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

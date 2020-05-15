using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    // public float Geschwindigkeit;

    //public float Beschleunigung;

    //float aktuelleGeschwindigkeit = 0;

   
    private Vector3 richtung;
    private Vector3 endposition;

    void Start()

    {
      
    }



    void Update()

    {
        if (eingabeüberprüfen())
        {
            while (this.transform.position != endposition)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position,endposition,Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, transform.position+richtung, 0f);
            }
        }

        

    }

    private bool eingabeüberprüfen()
    {
        bool eingabe = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))  //"GetKeyDown" gibt nur einmal ein True zurück wenn er gedrückt wurde
        {                                       //"GetKey" gibt solange man gedrückt hält ein "True" zurück    
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                richtung = new Vector3(1.5f, 0f, 1);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                richtung = new Vector3(-1.5f, 0f, 1);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
            else
            {
                richtung = new Vector3(0f, 0f, 2);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                richtung = new Vector3(1.5f, 0f, -1);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                richtung = new Vector3(-1.5f, 0f, -1);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
            else
            {
                richtung = new Vector3(0f, 0f, -2);
                endposition = this.transform.position + richtung;
                eingabe = true;
            }
        }
        return eingabe;
    }

}


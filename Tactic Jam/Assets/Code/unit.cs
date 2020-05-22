using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 destination;
    float speed = 2;
    public List<MouseManager.Node> currentPath = null;
    //Position der Unit
    public int spalte;
    public int reihe;

    //int reichweite = 4;
    void Start()
    {
        destination = transform.position;
        spalte = 6;
        reihe = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (currentPath != null)
        {


            if (destination == transform.position)
            {

                moveNextTile();
                //Vector3 dir = destination - transform.position;


            }
            //Beweg dich zu dieser Position



        }
        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;

        //sorgt dafür, dass ich nicht über das Ziel hinausschieße
        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);
    }


    void moveNextTile()
    {
        //Die Erste Position wird gelöscht. Ist ja unsere Startposition
        currentPath.RemoveAt(0);

        //
        destination = new Vector3(currentPath[0].posx, 0, currentPath[0].posz);

        if (currentPath.Count == 1)
        {
            currentPath = null;
        }
    }

}


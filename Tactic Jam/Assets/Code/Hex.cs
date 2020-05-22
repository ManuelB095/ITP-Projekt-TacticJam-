using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    // Start is called before the first frame update

    public int x;
    public int z;


    /*public Hex[] GetNeighbor()
    {
        //über uns 
        GameObject upperNeighbour = GameObject.Find("Hex_" + x + "_" + (z + 1));
        //unter uns
        GameObject underNeighbour = GameObject.Find("Hex_" + x + "_" + (z - 1));

        if (x == 0)
        {
            GameObject upperleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z));
            GameObject upperrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z));
            GameObject underleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z - 1));
            GameObject underrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z - 1));
        }
        else if (x < 0)
        {
            GameObject upperleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z));
            GameObject upperrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z + 1));
            GameObject underleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z - 1));
            GameObject underrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z));
        }
        else if (x > 0)
        {
            GameObject upperleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z + 1));
            GameObject upperrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z));
            GameObject underleftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + (z));
            GameObject underrightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + (z - 1));
        }

    }*/



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

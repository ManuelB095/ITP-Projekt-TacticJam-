using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{

    public GameObject hextile;

    //max size of the map
    int line = 7;
    int collumn = 8;

    // Start is called before the first frame update
    void Start()
    {
        generateMap();
        //generatePathGraph();


    }



    public int getline()
    {
        return line;
    }
    public int getcollumn()
    {
        return collumn;
    }




    //Erstellt das Spielfeld
    void generateMap()
    {

        int r = 0;
        int s = 0;
        for (float x = 0; x < line; x++)
        {

            s = 0;
            for (float z = 0 + x; z < collumn; z++)
            {

                if (x == 0)
                {
                    GameObject hex_go = (GameObject)Instantiate(hextile, new Vector3(x, 0f, z * 2 - x), Quaternion.identity);

                    //GameObjects bekommen ihren eigenen Namen
                    hex_go.name = "Hex" + (line - 1) + "_" + (s - r);

                    hex_go.transform.SetParent(this.transform);

                    //Damit Hex weiß wo es auf der Map liegt
                    hex_go.GetComponent<Hex>().x = (line - 1);
                    hex_go.GetComponent<Hex>().z = s;
                    s++;
                }



                else
                {
                    GameObject hex_goright = (GameObject)Instantiate(hextile, new Vector3(x * 1.5f, 0f, z * 2 - x), Quaternion.identity);
                    hex_goright.name = "Hex" + (line - 1 + x) + "_" + (z - x);
                    hex_goright.transform.SetParent(this.transform);
                    hex_goright.GetComponent<Hex>().x = (line - 1) + r;
                    hex_goright.GetComponent<Hex>().z = (s);

                    GameObject hex_goleft = (GameObject)Instantiate(hextile, new Vector3(-x * 1.5f, 0f, z * 2 - x), Quaternion.identity);
                    hex_goleft.name = "Hex" + (line - 1 - x) + "_" + (z - x);
                    hex_goleft.transform.SetParent(this.transform);
                    hex_goleft.GetComponent<Hex>().x = (line - 1 - r);
                    hex_goleft.GetComponent<Hex>().z = (s);
                    s++;
                }

            }
            r++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

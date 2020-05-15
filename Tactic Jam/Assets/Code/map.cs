using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{

    public GameObject hextile;

    //max size of the map of the map
    int line = 5;
    int collumn = 6;

    // Start is called before the first frame update
    void Start()
    {

        for (float x = 0; x < line; x++)
        {

            for (float z = 0 + x; z < collumn; z++)
            {

                if (x == 0)
                {
                    GameObject hex_go = (GameObject)Instantiate(hextile, new Vector3(x, 0f, z * 2 - x), Quaternion.identity);
                    hex_go.name = "Hex" + x + "_" + (z - x);
                    hex_go.transform.SetParent(this.transform);
                    hex_go.GetComponent<Hex>().x = x;
                    hex_go.GetComponent<Hex>().z = z - x;
                }



                else
                {
                    GameObject hex_goright = (GameObject)Instantiate(hextile, new Vector3(x * 1.5f, 0f, z * 2 - x), Quaternion.identity);
                    hex_goright.name = "Hex" + x + "_" + (z - x);
                    hex_goright.transform.SetParent(this.transform);
                    hex_goright.GetComponent<Hex>().x = x;
                    hex_goright.GetComponent<Hex>().z = (z - x);

                    GameObject hex_goleft = (GameObject)Instantiate(hextile, new Vector3(-x * 1.5f, 0f, z * 2 - x), Quaternion.identity);
                    hex_goleft.name = "Hex" + (-x) + "_" + (z - x);
                    hex_goleft.transform.SetParent(this.transform);
                    hex_goright.GetComponent<Hex>().x = -x;
                    hex_goright.GetComponent<Hex>().z = (z - x);
                }





                //Instantiate(hextile, new Vector3(, 0, z * 2), Quaternion.identity);





            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}

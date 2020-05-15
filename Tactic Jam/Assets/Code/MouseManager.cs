using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    unit selectedUnit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ist die Maus über einem UI Element?

        //damit bekommen wir die Position der Maus auf unserem Feld
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        //Wenn wird mit der Mausposition ein Object treffen wird und das Object zurück gegeben
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

            //Über welchem Objekt befinden wir uns?
            if (ourHitObject.GetComponent<Hex>() != null)
            {
                MouseOver_Hex(ourHitObject);
            }

            else if (ourHitObject.GetComponent<unit>() != null)
            {
                MouseOver_unit(ourHitObject);
            }



        }
    }

    void MouseOver_Hex(GameObject ourHitObject)
    {

        //Haben wir eine Einheit ausgewählt?

        //Wenn man auf das Object klickt, wird die Farbe (MeshRenderer) verändert

        if (Input.GetMouseButtonDown(0))
        {
            MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

            if (mr.materials[1].color == Color.red)
            {
                mr.materials[1].color = Color.blue;
            }
            else
            {
                mr.materials[1].color = Color.red;
            }

            //wenn wir eine Einheit ausgewählt haben bewegen wir es auf das Hexfeld
            if (selectedUnit != null)
            {
                selectedUnit.destination = ourHitObject.transform.position;
                selectedUnit = null;
            }

        }

    }

    void MouseOver_unit(GameObject ourHitObject)
    {

        //Haben wir eine Einheit ausgewählt?

        //Wenn man auf das Object klickt, wird die Farbe (MeshRenderer) verändert

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit = ourHitObject.GetComponent<unit>();


        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private GameObject savedObject;
    private GameObject selectedUnit;

    private void Start()
    {
        savedObject = null;
        selectedUnit = null;
    }

    private void Update()
    {
        ClickEvent();
    }

    private void ClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider != null)
            {
                savedObject = hit.collider.gameObject;
            }

            ObjectAction();
        }
    }

    private void ObjectAction()
    {
        if(savedObject != null)
        {
            if(savedObject.GetComponent<Tile>() && selectedUnit == null)
            {
                Debug.Log("Tile " + savedObject.GetComponent<Tile>().GetRow() + "." + savedObject.GetComponent<Tile>().GetColumn() + " was clicked while no unit was selected");
                savedObject = null;
            }
            else if(savedObject.GetComponent<Unit>() && selectedUnit == null)
            {
                selectedUnit = savedObject;
                selectedUnit.GetComponent<Unit>().ShowPossibleDistance();
                Debug.Log("Unit is selected");
                savedObject = null;
            }
            else if(savedObject.GetComponent<Tile>() && selectedUnit != null)
            {
                selectedUnit.GetComponent<Unit>().MoveUnit(savedObject.GetComponent<Transform>(), savedObject);
                
                Debug.Log("Unit was moved to Tile " + savedObject.GetComponent<Tile>().GetRow() + "." + savedObject.GetComponent<Tile>().GetColumn());
                selectedUnit = null;
                savedObject = null;
            }
        }
    }

    

}

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
                Debug.Log("something got clicked!");
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
                savedObject.GetComponent<Tile>().OccupyTile();
            }
            else if(savedObject.GetComponent<Unit>() && selectedUnit == null)
            {
                selectedUnit = savedObject;
                Debug.Log("Unit is selected");
            }
            else if(savedObject.GetComponent<Tile>() && selectedUnit != null)
            {
                selectedUnit.GetComponent<Unit>().MoveUnit(savedObject.GetComponent<Transform>(), savedObject);
                selectedUnit = null;
                Debug.Log("Unit was moved");
            }
        }
    }

    

}

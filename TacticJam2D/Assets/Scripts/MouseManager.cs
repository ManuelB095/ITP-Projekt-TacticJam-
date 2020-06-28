using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private GameObject savedObject;
    private GameObject selectedUnit;
    private GameHandler gameHandler;

    private void Awake()
    {
        savedObject = null;
        selectedUnit = null;
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
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
            if(savedObject.GetComponent<Tile>() && selectedUnit == null) //Tile was clicked without a unit selected
            {
                savedObject = null;
            }
            else if(savedObject.GetComponent<Unit>() && selectedUnit == null) //Unit was clicked - Unit is being selected
            {
                if(savedObject.GetComponent<Unit>().GetUnitState() == 1)
                {
                    selectedUnit = savedObject;
                    selectedUnit.GetComponent<Unit>().ShowPossibleDistance();
                    savedObject = null;
                }
            }
            else if(savedObject.GetComponent<Unit>() && selectedUnit != null) //Unit was clicked while other Unit was already selected
            {
                if(selectedUnit == savedObject)
                {
                    selectedUnit = null;
                    savedObject = null;
                    GameObject.FindObjectOfType<TileMap>().UnshowPossibleDistance();
                    gameHandler.CheckForTurnEnd();
                    return;
                }
                if(savedObject.GetComponent<Unit>().GetUnitState() == 1)
                {
                    if(selectedUnit.GetComponent<Unit>().GetUnitState() == 2)
                    {
                        selectedUnit.GetComponent<Unit>().SetUnitState(3);
                    }
                    selectedUnit = savedObject;
                    selectedUnit.GetComponent<Unit>().ShowPossibleDistance();
                    savedObject = null;
                }
                if(savedObject.GetComponent<Unit>().GetUnitState() == 4)
                {
                    //Check Attackrange, if yes prepare attack, if no do nothing
                    if(selectedUnit.GetComponent<Unit>().HasSelectedEnemyInRange(savedObject.GetComponent<Unit>()))
                    {
                        Debug.Log("Unit can attack that enemy");
                        savedObject.GetComponent<Unit>().TakeDamage(selectedUnit.GetComponent<Unit>().GetAttackPower());
                        selectedUnit.GetComponent<Unit>().SetUnitState(3);
                        selectedUnit = null;
                    }
                    else
                    {
                        Debug.Log("Enemy Unit is out of range");
                        return;
                    }
                }
                GameObject.FindObjectOfType<TileMap>().UnshowPossibleDistance();
                gameHandler.CheckForTurnEnd();
                savedObject = null;
            }
            else if(savedObject.GetComponent<Tile>() && selectedUnit != null) //Tile was clicked while Unit was selected
            {
                if(savedObject.GetComponent<Tile>().IsShowingDistance())
                {
                    GameObject.FindObjectOfType<TileMap>().UnshowPossibleDistance();
                    selectedUnit.GetComponent<Unit>().MoveUnit(savedObject.GetComponent<Transform>(), savedObject.GetComponent<Tile>());
                    if (selectedUnit.GetComponent<Unit>().HasEnemyInRange())
                    {
                        selectedUnit.GetComponent<Unit>().SetUnitState(2);
                    }
                    else
                    {
                        selectedUnit.GetComponent<Unit>().SetUnitState(3);
                        selectedUnit = null;
                    }
                    gameHandler.CheckForTurnEnd();

                    savedObject = null;
                }
            }
        }
    }

    public void UnsetMouseObjects()
    {
        savedObject = null;
        selectedUnit = null;
        GameObject.FindObjectOfType<TileMap>().UnshowPossibleDistance();
    }

}

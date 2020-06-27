using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    private int[] unitsone = new int[3];

    private int[] unitstwo = new int[3];


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setunitsone(int unit, int type)
    {
        unitsone[unit] = type;
        print(unit + " Player One " + unitsone[unit]);
    }

    public int getunitsone(int unit)
    {
        return unitsone[unit];
    }

    public void setunitstwo(int unit, int type)
    {
        unitstwo[unit] = type;
        print(unit + " Player Two " + unitstwo[unit]);
    }

    public int getunitstwo(int unit)
    {
        return unitstwo[unit];
    }
}



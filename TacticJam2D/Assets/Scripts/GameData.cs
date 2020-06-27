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

    // Update is called once per frame
    public void setunitsone(int unit, int type)
    {
        unitsone[unit] = type;
        print(unitsone[unit]);
    }

    public int getunitsone(int unit)
    {
        return unitsone[unit];
    }

    public void setunitstwo(int unit, int type)
    {
        unitstwo[unit] = type;
        print(unitstwo[unit]);
    }

    public int getunitstwo(int unit)
    {
        return unitstwo[unit];
    }
}



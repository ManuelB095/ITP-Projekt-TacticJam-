using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    /*[Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColor;

    [Header("Sounds")]
    [SerializeField] private AudioClip arrowClickSFX;
    [SerializeField] private AudioClip characterSelectMusic; */

    public GameObject confirmBtn;
    public GameObject inputFieldLeft;
    public GameObject InputFieldRight;

    public int maxUnits;
    private int leftUnits = 0;
    private int rightUnits = 0;
    private int currentUnits;

    public void addUnitsToArmy()
    {
        if(leftUnits + rightUnits <= maxUnits)
        {
            currentUnits = leftUnits + rightUnits;
        }
        else
        {
            Debug.Log("Current selection exceeds Max Units allowed !");
        }
    }

    bool armyFull()
    {
        if (currentUnits == maxUnits)
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(armyFull())
        {
            confirmBtn.SetActive(true);
        }
        else
        {
            confirmBtn.SetActive(false);
        }
    }
}

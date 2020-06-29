using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public List<Image> healthbarImages;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void DisableHealthbar()
    {
        foreach(Image image in healthbarImages)
        {
            image.enabled = false;
        }
    }
}

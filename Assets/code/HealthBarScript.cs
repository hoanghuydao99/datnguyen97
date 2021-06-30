using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public int health;
    public Slider sliderHealth;
    public Slider sliderMana;
    //public static HealthBarScript instance;
    //[SerializeField] Sprite health0;
    //[SerializeField] Sprite health1;
    //[SerializeField] Sprite health2;
    //[SerializeField] Sprite health3;
    //[SerializeField] Sprite health4;
    //[SerializeField] Sprite health5;
    //[SerializeField] Sprite health6;
    //[SerializeField] Sprite health7;
    //[SerializeField] Sprite health8;
    //[SerializeField] Sprite health9;
    //[SerializeField] Sprite health10;
    //private SpriteRenderer changeSprite;
    // Start is called before the first frame update
    void Start()
    {
        //changeSprite = GetComponent<SpriteRenderer>();

        //if (instance == null)
        //
        //instance = this;
        //}
    }

    public void SetMaxHealth(int health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }

    public void SetHealth(int health)
    {
        sliderHealth.value = health;
    }

    public void SetMaxMana(int mana)
    {
        sliderMana.maxValue = mana;
        sliderMana.value = mana;
    }

    public void SetMana(int mana)
    {
        sliderMana.value = mana;
    }
    /*
    public void Mau(int maxHealth)
    {
        health = maxHealth;
        if (health == 10)
        {
            changeSprite.sprite = health0;
        }
        if (health == 9)
        {
            changeSprite.sprite = health1;
        }
        if (health == 8)
        {
            changeSprite.sprite = health2;
        }
        if (health == 7)
        {
            changeSprite.sprite = health3;
        }
        if (health == 6)
        {
            changeSprite.sprite = health4;
        }
        if (health == 5)
        {
            changeSprite.sprite = health5;
        }
        if (health == 4)
        {
            changeSprite.sprite = health6;
        }
        if (health == 3)
        {
            changeSprite.sprite = health7;
        }
        if (health == 2)
        {
            changeSprite.sprite = health8;
        }
        if (health == 1)
        {
            changeSprite.sprite = health9;
        }
        if (health == 0)
        {
            changeSprite.sprite = health10;
        }
    } */
}

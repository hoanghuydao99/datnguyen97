using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoBehaviour
{
    public Sprite[] Heartsprite;
    public player Player;
    public Image Heart;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.maxhealth > 10)
            Player.maxhealth = 10;


        if (Player.maxhealth < 0)
            Player.maxhealth = 0;

        Heart.sprite = Heartsprite[Player.maxhealth];
    }
}

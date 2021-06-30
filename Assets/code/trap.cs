using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    public player Player;
    public int damage =1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player.Damage(damage);
            if(Player.faceright)
                Player.Knockback(50f, Player.transform.position);
            else
                Player.Knockback(-50f, Player.transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkground : MonoBehaviour
{
    public player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.GetComponentInParent<player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            Player.grounded = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            Player.grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            Player.grounded = false;
    }
}

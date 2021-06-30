using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int Levelload = 1;
    public GM gm;
    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                //Levelload++;
                SceneManager.LoadScene(Levelload);
            //gm.text.text = ("Press E to enter");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.text.text = ("");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

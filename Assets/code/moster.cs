using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moster : MonoBehaviour
{
    float health;
    public float maxHealth;
    public Transform fillHealth;
    public GameObject panel;
    Vector3 scale;
    //public GameObject panel;
    // Start is called before the first frame update

    private void Start()
    {
        health = maxHealth;
        scale = fillHealth.localScale;
    }
    void Damage(int damage)
    {
        health -= damage;
        scale.x = health / maxHealth;
        fillHealth.localScale = scale;
        if (health <= 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
    }
    void Update()
    {
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //    if (this.gameObject.name == "boss") {
        //        panel.SetActive(true);
        //    }
        //}
    }

   
}

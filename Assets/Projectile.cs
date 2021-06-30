using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    Animator anim;
    bool isCollision = false;
    public float lifeTime;
    public int dame;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        anim = GetComponent<Animator>();
        //Invoke("PlayCollision", lifeTime);
    }

    void Update()
    {
        if (isCollision == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                anim.SetTrigger("Collision");
            }
        }
    }

    void PlayCollision()
    {
        isCollision = true;
        anim.SetTrigger("Collision");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player>().Damage(dame);
            PlayCollision();
        }
    }
    void Done()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Kill2_FrieBall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D myRigidbody;
    private Vector2 direction;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //   direction = Vector2.right;
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;

    }
    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
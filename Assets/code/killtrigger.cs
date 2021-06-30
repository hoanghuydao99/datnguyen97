using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killtrigger : MonoBehaviour
{
	public float speed = 10f;
	public int damage = 50;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	public float lifetime = 2;
	private void Update()
	{
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
		{
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.isTrigger != true && col.CompareTag("Enemy"))
		{
			col.SendMessageUpwards("Damage", damage);
			GameObject destroy = Instantiate(impactEffect, transform.position, Quaternion.identity);
			Destroy(destroy, 0.2f);
			Destroy(this.gameObject);

		}
		if (col.isTrigger != true && col.CompareTag("Ground"))
		{
			GameObject destroy = Instantiate(impactEffect, transform.position, Quaternion.identity);
			Destroy(destroy, 0.2f);
			Destroy(this.gameObject);

		}

	}
}

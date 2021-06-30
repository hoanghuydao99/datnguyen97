using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinn : MonoBehaviour
{
    GameObject player;
    SpriteRenderer spriteRenderer;
    public Transform fillHealth;
    public GameObject projectile;
    public int rangeAttack;
    public float timeDelay;
    public float startTimeDelay;
    public GameObject shootPoint;
    public float maxHealth;
    float currentHealth;
    Vector3 scale;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeDelay = startTimeDelay;
        currentHealth = maxHealth;
        scale = fillHealth.localScale;
    }

    // Update is called once per frame
    void Update()
    {   
        if (currentHealth <= 0) { return; }
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
            Vector3 newPos = shootPoint.transform.localPosition;
            newPos.x = 0.633f;
            shootPoint.transform.localPosition = newPos;
        }
        else
        {
            spriteRenderer.flipX = true;
            Vector3 newPos = shootPoint.transform.localPosition;
            newPos.x = -0.633f;
            shootPoint.transform.localPosition = newPos;
        }

        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= rangeAttack)
        {
            if (timeDelay <= 0)
            {
                anim.SetBool("Attacking", true);
                timeDelay = startTimeDelay;
            }
            else
            {
                timeDelay -= Time.deltaTime;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
        Vector3 shooDir = (player.transform.position - transform.position).normalized;
        bullet.transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shooDir));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void Damage(int damage)
    {
        currentHealth -= damage;
        updateHealth();
        if (currentHealth <= 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");
        }
    }


    void updateHealth()
    {
        scale.x = currentHealth / maxHealth;
        fillHealth.localScale = scale;
    }

    void AttackDone()
    {
        anim.SetBool("Attacking", false);
    }



    void Death()
    {
        Destroy(gameObject);
    }
}

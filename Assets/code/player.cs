using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    public float kill2Delay = 0.3f;
    public bool kill2 = false;

    [SerializeField]
    private GameObject frieBallPrefab;
    public float speed = 30f, maxspeed = 3, maxjump = 5, jumPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;
    public int maxhealth;
    private int ourHealth;
    public int maxMana;
    private int ourMana;
    public Rigidbody2D r2;
    public Animator anim;
    public sound Sound;
    public GM gm;
    public HealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        //ourHealth = maxhealth;
        Sound = GameObject.FindGameObjectWithTag("sound").GetComponent<sound>();
        ourHealth = maxhealth;
        ourMana = maxMana;
        healthBar.SetMaxHealth(maxhealth);
        healthBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("ButtonJump"))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumPow * 1.5f);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && !kill2 || CrossPlatformInputManager.GetButtonDown("ButtonSkill") && !kill2)
        {
            if (ourMana >= 10)
            {
                Sound.Playsound("FireBall");
                kill2 = true;
                // trigger.enabled = true;
                anim.SetTrigger("Kill2");
                kill2Delay = 0.3f;
                _Kill2FrieBall(0);
                ourMana -= 10;
                healthBar.SetMana(ourMana);
                Debug.Log(ourMana);
            }
        }

        if (kill2)
        {
            if (kill2Delay > 0)
            {
                kill2Delay -= Time.deltaTime;

            }
            else
            {
                kill2 = false;
                // trigger.enabled = false;

            }
        }
        anim.SetBool("Kill2", kill2);
    }
    private void FixedUpdate()
    {
        //HealthBarScript.instance.Mau(maxhealth);
        float h = Input.GetAxis("Horizontal");
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        //gioihan speed
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        //if (r2.velocity.y > maxjump)
          //  r2.velocity = new Vector2(r2.velocity.x, maxjump);
        //if (r2.velocity.y < -maxjump)
          //  r2.velocity = new Vector2(r2.velocity.x, -maxjump);
        if (h > 0 && !faceright)
        {
            Flip();
        }
        if (h < 0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damege)
    {
        ourHealth -= damege;
        healthBar.SetHealth(ourHealth);
        if (ourHealth <= 0)
        {
            Death();
        }
        Debug.Log(ourHealth);
        //gameObject.GetComponent<Animation>().Play("redflat");
    }
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * Knockpow, Knockdir.y *-50));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            Sound.Playsound("coins");
            //Destroy(collision.gameObject);
            //maxhealth = 10;
            ourHealth += 2;
            if (ourHealth > maxhealth)
            {
                ourHealth = maxhealth;
            };
            Destroy(collision.gameObject);
            healthBar.SetHealth(ourHealth);
        } else if (collision.gameObject.CompareTag("Mana"))
        {
            ourMana += 20;
            if (ourMana > maxMana)
            {
                ourMana = maxMana;
            }
            Destroy(collision.gameObject);
            healthBar.SetMana(ourMana);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag.Equals("hop"))
        {
            this.transform.parent = collision.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (this.gameObject.activeSelf == true) this.transform.parent = null;
    }
    public void _Kill2FrieBall(int value)
    {


        if (faceright)
        {
            GameObject tmp = (GameObject)
            Instantiate(frieBallPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.Euler(new Vector3(0, -10, 0)));
            //tmp.GetComponent<Kill2_FrieBall>().Initialize(Vector2.right);
        }
        else
        {

            GameObject tmp = (GameObject)
        Instantiate(frieBallPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.Euler(new Vector3(0, -10, -180)));
            //tmp.GetComponent<Kill2_FrieBall>().Initialize(Vector2.left); ;

        }


    }

    public void FinishGame()
    {
        SceneManager.LoadScene(0);
    }
}

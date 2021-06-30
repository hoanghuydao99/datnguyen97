using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moviRight = true;
    public Transform groundDetection;
    private player p;
    private GameObject plr;
    private bool move = true;
    private bool isDMG = false;
    public float atkDist = 4.5f;
    public int dame = 2;
    public GameObject projectile;
    public int rangeAttack;
    public float timeDelay;
    public float startTimeDelay;
    public GameObject shootPoint;

    private void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player");
        p = plr.GetComponent<player>();
    }

    private void Update()
    {
        if (move) transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (moviRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;
            }
        }
        if (Vector3.Distance(this.transform.position, plr.transform.position) < atkDist)
        {
            move = false;

            if (!isDMG)
            {
                StartCoroutine(damage());
                isDMG = true;
            }

            this.GetComponent<Animator>().SetTrigger("Atk");
            if (moviRight && plr.transform.position.x < this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;

            }
            if (!moviRight && plr.transform.position.x > this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;

            }
        }
        else
        {
            move = true;
            this.GetComponent<Animator>().SetTrigger("Move");
        }

        if (gameObject.name == "boss")
        {
            float distanceP = Vector2.Distance(plr.transform.position, transform.position);
            if (distanceP <= rangeAttack)
            {
                if (timeDelay <= 0)
                {
                    timeDelay = startTimeDelay;
                    Fire();
                }
                else
                {
                    timeDelay -= Time.deltaTime;
                }
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
        Vector3 shooDir = (plr.transform.position - transform.position).normalized;
        bullet.transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shooDir));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }


    public IEnumerator damage()
    {
        yield return new WaitForSeconds(2);
        p.Damage(dame);
        isDMG = false;
    }

}

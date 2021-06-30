using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbossmove : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moviRight = true;
    public Transform groundDetection;
    public player p;
    public GameObject plr;
    private bool move = true;
    private bool isDMG = false;
    public float atkDis = 1.5f;
    public int dame = 1;

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
        if (Vector3.Distance(this.transform.position, plr.transform.position) < atkDis)
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
    }

    public IEnumerator damage() {
        yield return new WaitForSeconds(2);
        p.Damage(dame);
        isDMG = false;
    }

}

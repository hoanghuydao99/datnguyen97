using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerattack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;
    public Animator anim;
    public Collider2D trigger;
    public sound Sound;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        Sound = GameObject.FindGameObjectWithTag("sound").GetComponent<sound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking || CrossPlatformInputManager.GetButtonDown("ButtonAttack") && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            Sound.Playsound("soundattack");
        }
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;//chay theo realtime
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        anim.SetBool("attacking", attacking);
    }
}

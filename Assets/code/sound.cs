using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip soundattack, coins, fireball;
    public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("coins");
        soundattack = Resources.Load<AudioClip>("soundattack");
        fireball = Resources.Load<AudioClip>("FireBall");
        adisrc = GetComponent<AudioSource>();
    }
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "soundattack":
                adisrc.clip = soundattack;
                adisrc.PlayOneShot(soundattack, 1f);
                break;
       
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 1f);
                break;

            case "FireBall":
                adisrc.clip = fireball;
                adisrc.PlayOneShot(fireball, 1f);
                break;
        }
    }
}

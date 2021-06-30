using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    AudioSource audio;
    AudioListener listener;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("Music"));
        audio = GetComponent<AudioSource>();
        listener = GetComponent<AudioListener>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

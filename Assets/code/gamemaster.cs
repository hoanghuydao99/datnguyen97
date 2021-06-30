using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour
{
    public int highScore = 0;
    public Text Hightext;
    public Text Inputtext;
    // Start is called before the first frame update
    void Start()
    {
        Hightext.text = ("HighScore: " + PlayerPrefs.GetInt("highscore"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public Sprite musicOn;
    public Sprite musicOff;
    bool stateMusic = true;
    public Image btnMusic;
    private void Start()
    {
        PlayerPrefs.SetInt("Music", 0);
    }
    public void PlayInGame()
    {
        SceneManager.LoadScene("Map1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClickMusic()
    {
        stateMusic = !stateMusic;
        if (stateMusic == true)
        {
            btnMusic.sprite = musicOn;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            btnMusic.sprite = musicOff;
            PlayerPrefs.SetInt("Music", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("Music"));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private bool Pause = false;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause = !Pause;
        }
        if (Pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (Pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void resume()
    {
        Pause = false;
    }
    public void restar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }

}

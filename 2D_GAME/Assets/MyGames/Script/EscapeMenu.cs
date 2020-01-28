using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject play;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        play = GameObject.Find("Canvas/DeathMenu/Button_Play");
        if (play.gameObject.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0001f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}

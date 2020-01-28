using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu2D : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject[] panels;
    public GameObject[] _otherpanels;

    public GameObject[] _autoopen;

    public bool _canopen;


    public void SetActivePanel(int index)
    {
        for (var i = 0; i < panels.Length; i++)
        {
            var active = i == index;
            var g = panels[i];
            if (g.activeSelf != active) g.SetActive(active);
        }
        _canopen = true;
    }

    public void OnClickButton()
    {
        Debug.Log("Button's working");
    }
    void OnEnable()
    {
        SetActivePanel(0);
    }
    void Update()
    {
   


        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                for (var i = 0; i < _otherpanels.Length; i++)
                {
                    if (_otherpanels[i].activeSelf)
                    {
                        Debug.Log(_otherpanels[i]);
                        Debug.Log(_otherpanels[i].activeSelf);
                       _otherpanels[i].SetActive(false);
                        Debug.Log(_otherpanels[i].activeSelf);
                        _canopen = false;
                        i = _otherpanels.Length;
                    }
                    else _canopen = true;
                }
                if (_canopen)
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
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
/*        for (var i = 0; i < _autoopen.Length ; i++){
            _autoopen[i].SetActive(true);
        }*/
        Time.timeScale = 0.0000000000001f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        /*        for (var i = 0; i < _autoopen.Length; i++)
                {
                    _autoopen[i].SetActive(false);
                }*/
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Menu;

    void Start()
    {
        Menu = GameObject.Find("MainMenu");
        //Levels = GameObject.Find("Levels");



    }
    public void PlayGame()
    {
        Levels.SetActive(true) ;
        Menu.SetActive(false);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Back()
    {
        Levels.SetActive(false);
        Menu.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }  

}

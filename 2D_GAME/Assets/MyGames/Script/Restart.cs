using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
   
    private GameObject player;
    public GameObject checkpoint;
    public float stopdistance;
    public float maxrange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      //  player.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + 0.2f);
    }

    public void Exit()
    {

        SceneManager.LoadScene("MainMenu");
        
    }
}

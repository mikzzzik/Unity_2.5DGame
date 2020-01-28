using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAder : MonoBehaviour
{

    public Text ScoreControl;
    private int score;


    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreControl = GameObject.Find("Score").GetComponent<Text>();
        score = int.Parse(ScoreControl.text);
        if(other.tag == "Player")
        {
            score++;
            Destroy(gameObject);
        }
        ScoreControl.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitAddPoint : MonoBehaviour
{ 

public Text ScoreControl;
private int score;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreControl = GameObject.Find("Score").GetComponent<Text>();
            score = int.Parse(ScoreControl.text);
            score++;
            ScoreControl.text = score.ToString();
        }
//        Destroy(gameObject);
    }
}

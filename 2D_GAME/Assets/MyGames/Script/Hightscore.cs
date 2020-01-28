using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hightscore : MonoBehaviour
{
    public Text hightscore;
    private int hightscore_wal;
    public Text Score;
    private int Score_Wal;
    void Start()
    {
        hightscore.text = PlayerPrefs.GetInt("Hightscore").ToString();
        // Score_Wal = int.Parse(Score.text);

    }

    // Update is called once per frame
    void Update()
    {
       
        
        Score_Wal = int.Parse(Score.text);
       // Debug.Log(Score_Wal);
        if (Score_Wal > int.Parse(hightscore.text))
        {
            PlayerPrefs.SetInt("Hightscore", Score_Wal);
        
        }
        PlayerPrefs.Save();
    }
}

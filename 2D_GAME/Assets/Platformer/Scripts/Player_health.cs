using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public int health;
    public Image healthsprite;
    public Sprite hp3;
    public Sprite hp2;
    public Sprite hp1;
    public Sprite hp0;

    // Update is called once per frame
    void Update()
    {
           if( health == 3)
        {
            healthsprite.sprite = hp3;
        }
           if(health == 2)
        {
            healthsprite.sprite = hp2;
        }
           if(health == 1)
        {
            healthsprite.sprite = hp1;
        }
           if(health == 0)
        {
            healthsprite.sprite = hp0;
            Time.timeScale = 0f;
        }
    }
             
}



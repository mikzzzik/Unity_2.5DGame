using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving : MonoBehaviour
{
    public Move_blocks move1;
    public Move_blocks move2;
    public Move_blocks move3;
    public Move_blocks move4;
    public Move_blocks move5;
    public Move_blocks move6;
    public Move_blocks move7;
    public Move_blocks move8;
    public Move_blocks move9;
    public Move_blocks move10;
    public Move_blocks move11;
    public Move_blocks move12;
    public Move_blocks move13;
    public Move_blocks move14;
    private float time_b;
    private bool enable = false;

    // Start is called before the first frame update



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enable = true;
        }
    }
    private void Update()
    {
        if (enable)
        {
            time_b += Time.deltaTime;
            if (time_b > 0)
            {
                move1.movespeed = -0.4f;
                move2.movespeed = 0.4f;

            }
            if (time_b > 0.2f)
            {
                move3.movespeed = -0.4f;
                move4.movespeed = 0.4f;

            }
            if (time_b > 0.4f)
            {
                move5.movespeed = -0.4f;
                move6.movespeed = 0.4f;

            }
            if (time_b > 0.6f)
            {
                move7.movespeed = -0.4f;
                move8.movespeed = 0.4f;

            }
            if (time_b > 0.8f)
            {
                move9.movespeed = -0.4f;
                move10.movespeed = 0.4f;
            }
            if (time_b > 1f)
            {
                move11.movespeed = -0.4f;
                move12.movespeed = 0.4f;

            }
            if (time_b > 1.2f)
            {
                move13.movespeed = -0.4f;
                move14.movespeed = 0.4f;

            }
           // Debug.Log(time_b);
        }
    }
}

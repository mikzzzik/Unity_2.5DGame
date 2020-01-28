using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadByTouch : MonoBehaviour
{
    public Player_health controller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            controller.health = 0;
            //Destroy(gameObject);
        }
    }
}

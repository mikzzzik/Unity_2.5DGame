using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Player_health controller;
    public PlayerMove move;
    private int x;

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            controller.health-=1;
            
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (Input.GetAxis("Horizontal") > 0)
            {
                x = 1;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                x = -1;
            }
            move.isGrounded = false;
            rb.AddForce(Vector2.left * (4000 * x));
            rb.AddForce(Vector2.up * 400);

        }
    }
}

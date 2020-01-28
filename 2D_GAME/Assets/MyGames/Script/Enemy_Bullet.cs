using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    private GameObject player;
    private float timeAlive = 0;
    void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Destroy(gameObject);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
       
        

    }
    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 5)
        {
            Destroy(gameObject);
        }
    }
}

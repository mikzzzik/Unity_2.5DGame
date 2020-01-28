using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet : MonoBehaviour
{

    private GameObject player;
    private float timeAlive = 0;
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
        if (timeAlive > 20)
        {
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bullet : MonoBehaviour
{
    public float speed = 15f;
    private float flytime = 1.5f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    void Update()
    {
        flytime -= Time.deltaTime;
        if (flytime < 0)
        {
            flytime = 1.5f;
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border" || other.tag == "Moving_Blocks")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame

}

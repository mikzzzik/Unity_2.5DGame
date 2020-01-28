using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rg;
    private float flytime = 1.5f;
    void Start()
    {
        rg.velocity = transform.right * speed;
    }
    private void Update()
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
        if (other.tag == ("Border") || other.tag == "Boss")
        {
            Destroy(gameObject);
        }
        
    }

}

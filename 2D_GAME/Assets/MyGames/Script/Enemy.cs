using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    public float speed = 2;

    public GameObject projectile;
    private Transform player;
    private float distance;
    private bool moveright;

    void Start()
    {
        moveright = true;  
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.position, this.gameObject.transform.position);
        //Debug.Log(distance);
        if (timeBtwShots <= 0 && player.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static && distance <=15)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (distance < 20)
        if (moveright)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else if (!moveright)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Patrol_Trigger")
        {
            if (moveright)
            {
                moveright = false;
            }
            else if (!moveright)
            {
                moveright = true;
            }
        }

    }
}
   

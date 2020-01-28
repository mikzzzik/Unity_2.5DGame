using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPig : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    public float speed = 2;
    public LayerMask groundLayer;
    public GameObject projectile;
    private Transform player;
    private float distance;
    private bool moveright;
    Rigidbody2D rb;
    public  float jumpForce = 0;

    void Start()
    {
        moveright = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {      
        Vector3 flip = transform.localScale;
        distance = Vector2.Distance(player.position, this.gameObject.transform.position);
        if (distance < 60)
            if (moveright)
            {
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);                          
                flip.x = Mathf.Abs(transform.localScale.x) * -1;
            }
            else if (!moveright)
            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);                              
                flip.x = Mathf.Abs(transform.localScale.x);

            }
   
            transform.localScale = flip;
        Debug.DrawRay(transform.position, new Vector2(-1.2f*(flip.x), 0), Color.red);
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, new Vector2(-1.2f * (flip.x), 0), 1.2f, groundLayer);
        if (Hit.collider != null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpForce);
/*            Debug.Log("Hit!");*/
        }
        //RaycastHit2D Hit = Physics2D.Raycast(new Vector2(transform.localPosition.x, transform.localPosition.y - 0.6f), new Vector2(0, -0.1f), 0.1f);
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

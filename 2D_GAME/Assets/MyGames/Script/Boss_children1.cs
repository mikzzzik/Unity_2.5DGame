using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_children1 : MonoBehaviour
{
    private Transform player;
    private float distance;
    public float startTimeBtwShots = 2f;
    public float speed = 2f;
    private float timeBtwShots;
    public Transform shootpos;
    public GameObject Bullet_Chil;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.position, this.gameObject.transform.position);
        if (distance < 32)
        {
            if (timeBtwShots <= 0 && player.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            {
                Instantiate(Bullet_Chil, shootpos.position, shootpos.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else timeBtwShots -= Time.deltaTime;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

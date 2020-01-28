using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_level1 : MonoBehaviour
{
    public GameObject Teleport1;
    public GameObject Teleport2;
    public GameObject Teleport3;
    private Transform player;
    private int HP_Amount;
    private int Shots, num1;
    public Transform Firepos1;
    public Transform Firepos2;
    public Transform Firepos3;
    public Transform ChildrenPos;
    public GameObject BossBullet;
    public GameObject Boss_Childer;
    private float distance;
    public float startTimeBtwShots = 2f;
    public float speed = 2f;
    private float timeBtwShots;
    private int Hits = 0;
    private float time_b = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        HP_Amount = 6;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {       
        distance = Vector2.Distance(player.position, this.gameObject.transform.position);
        if (distance < 32) {
            if (timeBtwShots <= 0 && player.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            {
                Shot();
                timeBtwShots = startTimeBtwShots;
            }
            else timeBtwShots -= Time.deltaTime; 
           
        }  
 
        if (Hits == 5)
        {
            Teleport();
            Hits = 0;
        }   
        if (HP_Amount <= 5 )
        {
            LowHP();
        }
        
        if (HP_Amount == 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log(distance);
    }
    void Shot()
    {
        Shots = Random.Range(1, 4);
        switch (Shots)
        {
            case 1:
                Instantiate(BossBullet, Firepos1.position, Firepos1.rotation);
                break;
            case 2:
                Instantiate(BossBullet, Firepos1.position, Firepos1.rotation);
                Instantiate(BossBullet, Firepos2.position, Firepos2.rotation);
                break;
            case 3:
                Instantiate(BossBullet, Firepos1.position, Firepos1.rotation);
                Instantiate(BossBullet, Firepos2.position, Firepos2.rotation);
                Instantiate(BossBullet, Firepos3.position, Firepos3.rotation);
                break;
            default:
                Instantiate(BossBullet, Firepos1.position, Firepos1.rotation);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Teleport();
        }
        if (other.tag == "Bullet")
        {
            HP_Amount -= 1;
            Hits++;
        }


   }
    void Teleport()
    {
        num1 = Random.Range(1, 3);
        if (this.transform.position.x == Teleport1.transform.position.x)
        {
            switch (num1)
            {
                case 1: this.transform.position = new Vector2(Teleport2.transform.position.x, Teleport2.transform.position.y); break;
                case 2: this.transform.position = new Vector2(Teleport3.transform.position.x, Teleport3.transform.position.y); break;
            }
        }
        else if (this.transform.position.x == Teleport2.transform.position.x)
        {
            switch (num1)
            {
                case 1: this.transform.position = new Vector2(Teleport1.transform.position.x, Teleport1.transform.position.y); break;
                case 2: this.transform.position = new Vector2(Teleport3.transform.position.x, Teleport3.transform.position.y); break;
            }
        }
        else
        {
            switch (num1)
            {
                case 1: this.transform.position = new Vector2(Teleport1.transform.position.x, Teleport1.transform.position.y); break;
                case 2: this.transform.position = new Vector2(Teleport2.transform.position.x, Teleport2.transform.position.y); break;
            }
        }
    }
    private void LowHP()
    {
        time_b += Time.deltaTime;
        Debug.Log(time_b);
        if (time_b > 10) {
            time_b = 0;
            Instantiate(Boss_Childer, ChildrenPos.position, ChildrenPos.rotation);        
            Teleport();
        }

    }
}

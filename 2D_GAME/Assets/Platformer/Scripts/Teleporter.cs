using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TP_Zone;
 //   public Move cord;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player")
        {
            Player.transform.position = new Vector2(TP_Zone.transform.position.x, TP_Zone.transform.position.y + 0.2f);
           // cord.checkpoint = TP_Zone;
        }
    }
}

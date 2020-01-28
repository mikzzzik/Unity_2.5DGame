using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    private Transform player;
    public DoorController Door;
    private bool status;
    void Start()
    {
        status = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Door.Opened+ "   " + status);
        
        if (Door.Opened == 1)
        {
          
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (!status)
        {
            if (Door.Opened == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            status = true;
        }
        else status = false;
    }
}

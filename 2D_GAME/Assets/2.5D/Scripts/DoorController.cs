using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirstDoor;
    public Transform SecondDoor;
    private Transform player;

    public GameObject Shadow;
    
    public float movespeed;
    public int Opened;
    private bool status = false;
    void Start()
    {
        Opened = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Opened);
        if (Opened == 1)
        {
            Open();
        }
        else if (Opened == 3)
        {
            Close();
        }
        if (Vector2.Distance(this.transform.position, player.position) < 1.5f){
            if (Input.GetAxisRaw("Open") == 1 && Opened == 0)
            {
                Opened = 1;
                Shadow.SetActive(false);
            }
            if (Input.GetAxisRaw("Open") == 1 && Opened == 2)
            {
                Opened = 3;
            }
            if (!status && Opened == 0)
            {
                Shadow.SetActive(true);
            } 
        }
        //Debug.Log(Opened + "  " + status);
    }
    private void Open()
    {

        if (Vector2.Distance(FirstDoor.position, SecondDoor.position) < 1.35f)
        {
            FirstDoor.transform.Translate(2 * Time.deltaTime * (-1 * movespeed), 0, 0);
            SecondDoor.transform.Translate(2 * Time.deltaTime * movespeed, 0, 0);
        }
        else Opened = 2;
    }

    private void Close()
    {
        if (Vector2.Distance(FirstDoor.position, SecondDoor.position) >= 0.49f)
        {
            FirstDoor.transform.Translate(2 * Time.deltaTime * movespeed, 0, 0);
            SecondDoor.transform.Translate(2 * Time.deltaTime * (-1 * movespeed), 0, 0);
        }
        else
        {  
            Opened = 0;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Box")
        {
            if (!status)
            {
                status = true;
            } 
            else if (status)
            {
                status = false;
            }
        }

    }
}

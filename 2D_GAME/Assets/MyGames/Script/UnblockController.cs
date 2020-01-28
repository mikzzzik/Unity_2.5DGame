using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockController : MonoBehaviour
{
    public GameObject player;
    public Move control;
    
    void Start()
    {
    player = GameObject.FindGameObjectWithTag("Player");
   
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("IT'S WORKING");
            if (control.Unlock) control.Unlock = false;
            else control.Unlock = true;
            Debug.Log(control.Unlock);


        }
    }
}

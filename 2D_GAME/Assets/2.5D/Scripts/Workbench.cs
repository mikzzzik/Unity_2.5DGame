using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{

    private Transform pl;

    public GameObject WB_Panel;

    void Start()
    {

        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

   
    void Update()
    {

        if ((Vector2.Distance(this.transform.position, pl.position) < 0.75f))
        {

            if (Input.GetButtonDown("Open") )
            {
                if (!WB_Panel.activeSelf)
                {
                    WB_Panel.SetActive(true);
                }
                else WB_Panel.SetActive(false);
            }


        }
        else
        {
            WB_Panel.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_blocks : MonoBehaviour
{
    public float movespeed = 0;
    private float time_b;
    void Update()
    {
        transform.Translate(0, 2 * Time.deltaTime * movespeed, 0);
        if(movespeed != 0 )
        {
            time_b += Time.deltaTime;
            if(time_b > 5)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Border")
        {
            movespeed = 0;
        }
    }
}

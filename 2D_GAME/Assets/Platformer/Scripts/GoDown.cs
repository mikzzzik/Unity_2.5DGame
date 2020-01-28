using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    public LayerMask groundLayer;
    void Update()
    {

           
        Debug.DrawRay(new Vector2(transform.localPosition.x, this.transform.localPosition.y-4), new Vector2(0, -0.2f), Color.red);
        RaycastHit2D Hit = Physics2D.Raycast(new Vector2(transform.localPosition.x, this.transform.localPosition.y - 4),
                                             new Vector2(0, -0.1f),
                                             0.1f,
                                             groundLayer);
        if (Hit.collider == null)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-0.25f);
        }
    }
}





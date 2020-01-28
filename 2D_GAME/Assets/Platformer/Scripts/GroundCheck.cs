using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMove py;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            py.isGrounded = true;
        }
        if (!other.gameObject.CompareTag("Ground"))
        {
            py.isGrounded = false;
        }
    }
}

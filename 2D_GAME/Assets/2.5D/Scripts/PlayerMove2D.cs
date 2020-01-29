using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public bool CanMove;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;
    public Vector2 flip;
    private Animator m_Animator;
    private float cooldown;
    private void Start()
    {
        Time.timeScale = 1f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        flip = transform.localScale;
        CanMove = true;
    }

   
   private void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate()
    {

        if (CanMove)
        {
            if (movement.y != 0 && movement.x == 0)
            {
                if (movement.y > 0)
                {
                    m_Animator.SetBool("RunTop", true);
                    m_Animator.SetBool("Rundown", false);
                }
                else
                {
                    m_Animator.SetBool("RunDown", true);

                    m_Animator.SetBool("RunTop", false);
                }

            }
            else
            {
                m_Animator.SetBool("RunTop", false);
                m_Animator.SetBool("RunDown", false);
            }
            /////////////////////////////////////// Top Side
            if (movement.x != 0 && movement.y > 0)
            {
                m_Animator.SetBool("RunTopSide", true);
            }
            else m_Animator.SetBool("RunTopSide", false);
            if (movement.x != 0 && movement.y < 0)
            {
                m_Animator.SetBool("RunDownSide", true);
            }
            else m_Animator.SetBool("RunDownSide", false);
            /////////////////////////////////////// Left Right
            if (movement.x != 0)
            {

                m_Animator.SetBool("RunSide", true);
                if (movement.x == 1)
                {
                    flip.x = 1.2f;
                }
                else
                    flip.x = -1.2f;
                transform.localScale = flip;
            }
            else m_Animator.SetBool("RunSide", false);
            //cooldown = 0.4f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            m_Animator.SetBool("RunTop", false);
            m_Animator.SetBool("RunDown", false);
            m_Animator.SetBool("RunSide", false);
            m_Animator.SetBool("RunTopSide", false);
            m_Animator.SetBool("RunDownSide", false);
            cooldown -= Time.deltaTime;
           // if (cooldown < 0)
           // ;
           // }
        }
        
    }
}

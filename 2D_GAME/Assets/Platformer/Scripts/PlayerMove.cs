using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isGrounded;
    public float jumpForce;
    public   float moveSpeed = 5f;
    Rigidbody2D rb;
    private Animator m_Animator;
    public LayerMask groundLayer;
    private float cooldown = 0.5f;
    public Vector3 flip;
    public float x;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        Time.timeScale = 1f;
        flip = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {           
        Debug.DrawRay(new Vector2(transform.position.x - 0.06f, transform.position.y - 1.4f),
                      new Vector2(0, -0.15f),
                      Color.red);
        RaycastHit2D Hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.06f, transform.position.y - 1.4f),
                                             new Vector2(0, -0.15f),
                                             0.15f,
                                             groundLayer);
        if (Hit.collider != null)
        {
            isGrounded = true;
/*            Debug.Log("Jump!");*/
        }

        cooldown -= Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded && cooldown < 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            cooldown = 0.5f;
        }
       
        x = Input.GetAxis("Horizontal");

        m_Animator.SetFloat("Speed", Mathf.Abs(x));
        if (Time.timeScale != 0) {
            Vector3 move = new Vector3(x * moveSpeed, rb.velocity.y, 0f);
            rb.velocity = move;
        }
        if (x > 0 )
        {
            flip.x = Mathf.Abs(transform.localScale.x);
            
        }
        if (x < 0)
        {
            flip.x = Mathf.Abs(transform.localScale.x) *-1f;
      
        }
        /* GameObject Player = GameObject.FindGameObjectWithTag("Player");
         if (Input.mousePosition.x < Screen.width / 2)
         {
             Player.transform.rotation = Quaternion.Euler(0, 180, 0);

         }
         else
         {
             Player.transform.rotation = Quaternion.Euler(0, 0, 0);

         }*/
        //        Debug.Log(Time.timeScale);
        transform.localScale = flip;

    }

}


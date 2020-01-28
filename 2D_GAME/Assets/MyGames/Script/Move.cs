using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
 
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    private Animator m_Animator;
    private bool m_FacingRight = true;
    private float moveHorizontal;
    private float move = 0f;
    public float jumpPower = 150f;
    private bool CanJump = true;
    public AudioClip soundclip;
    public AudioSource soundscream;
    public bool Unlock = false;
    private GameObject play;
    private GameObject quit;
    public GameObject checkpoint;
    public GameObject Skip1Level;
    public GameObject Skip1;
    public GameObject Boss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("Flying", true);
        play = GameObject.Find("Canvas/DeathMenu/Button_Play");
        quit = GameObject.Find("Canvas/DeathMenu/Button_Tomain");
        //Unlock = true;
      //  this.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + 0.2f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F6))
        {
            this.transform.position = new Vector2(Skip1Level.transform.position.x, Skip1Level.transform.position.y + 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            this.transform.position = new Vector2(Skip1.transform.position.x, Skip1.transform.position.y + 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            this.transform.position = new Vector2(Boss.transform.position.x, Boss.transform.position.y + 0.2f);
        }
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);

        if (this.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            play.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
        }
       // Debug.Log(Unlock);
        if (Unlock == true && this.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        {
            if (Input.GetKey(KeyCode.A))
            {
                move = -1;
                Debug.Log("Left");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                move = 1;
                Debug.Log("Right");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (this.transform.rotation.y == -1)
            {
                move = this.transform.rotation.y;
            }
            if (this.transform.rotation.y != -1)
            {
                move = 1;
            }
        }
        
        if (this.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            m_Animator.SetBool("Flying", false);
        }
        //     m_Animator.SetFloat("SpeedCharacher", Mathf.Abs(moveHorizontal));
         //    m_Animator.SetBool("DeathCharacher", true);
        /*        if (move < 0 && m_FacingRight)
                  {
                    moveHorizontal = move * moveSpeed;
                    flip(move)
              }
              */
        moveHorizontal = move * moveSpeed;

        // }
        if (Input.GetButtonDown("Jump") && CanJump && Time.timeScale != 0 && this.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static) 
        {
            soundscream.PlayOneShot(soundclip);
            rb.AddForce(Vector2.up * jumpPower);
        }
        
    }
}
   
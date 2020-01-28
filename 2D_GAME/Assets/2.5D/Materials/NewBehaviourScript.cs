using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float speedMove;//Скорость персонажа
    public float speedRun = 4f;
    public float speedSprint = 7f;
    public float jumpPower;//Сила прыжка
    private float gravityForce;
    private Vector3 moveVector;//Направление движения персонажа
    private CharacterController ch_controller;
    private Animator ch_animator;
    private float time_delay;
    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        time_delay = 0;
    }
    private void Update()
    {
        CharacterMove();
        Gravity();
    }
    private void CharacterMove()
    {
        var xMove = Input.GetAxis("Horizontal");
        //перемещение по поверхности

        if (ch_controller.isGrounded)
        {
            ch_animator.ResetTrigger("Jump");
            ch_animator.SetBool("Fall", false);
        }
        moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedRun;
        }
        else
        {
            speed = speedMove;
        }

        moveVector.x = xMove * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);

        }
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            if (speed == speedMove)
            {
                ch_animator.SetBool("Move", true);
                ch_animator.SetBool("Run", false);
                ch_animator.SetBool("Sprint", false);
            }
            else
            {
                ch_animator.SetBool("Move", false);
                ch_animator.SetBool("Run", true);
                ch_animator.SetBool("Sprint", false);
            }

        }
        else
        {
            ch_animator.SetBool("Move", false);
            ch_animator.SetBool("Run", false);
            ch_animator.SetBool("Sprint", false);
        }
        if (gravityForce < -3f) ch_animator.SetBool("Fall", true);
        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);// метод передвижения по направлению
    }
    private void Gravity()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1;
        time_delay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded && time_delay <= 0)
        {
            time_delay = 1;
            gravityForce = jumpPower;
            ch_animator.SetTrigger("Jump");

        }
    }
}
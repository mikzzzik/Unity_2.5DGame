using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform shotpoint;

    public PlayerMove move;
    public GameObject bulletPrefab;
    //public AudioClip soundclip;
    //public AudioSource soundscream;

    public GameObject Player;
    public GameObject Weapon;

    private float cooldown = 1f;
    private float posbacker = 0.4f;
    private int flipper = 1;
    void Update()
    {
        if (Time.timeScale > 0.01)
        {
            Vector2 playerflipper = transform.localScale;
            Vector2 gunflipper = transform.localScale;
            float MousePosX = Input.mousePosition.x;
            Player = GameObject.FindGameObjectWithTag("Player");
            if (Time.timeScale != 0)
            {

                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 difference = (mousePos - transform.position);
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Debug.DrawRay(transform.position, new Vector2(difference.x, difference.y), Color.red);

                cooldown -= Time.deltaTime;
                if (Input.GetMouseButtonDown(0) && cooldown < 0)
                {
                    Shoot(rotZ, difference.x, difference.y);
                    cooldown = 1;
                    posbacker = 0.4f;
                    flipper = 1;
                }

                posbacker -= Time.deltaTime;
                if (posbacker < 0 && flipper != 0)
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                      
                        transform.localScale = new Vector2(0.5f, 0.5f);
                    }
                    else
                    {
                        
                        transform.localScale = new Vector2(0.5f, 0.5f);
                    }
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    flipper = 0;
                }
            }
            void Shoot(float rotZ, float x, float y)
            {
                
                
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    gunflipper.x = -0.5f;
                    gunflipper.y = -0.5f;
                    move.flip.x = Mathf.Abs(Player.transform.localScale.x) * -1f;
                    move.x = 0;
                    // playerflipper.x = Mathf.Abs(Player.transform.localScale.x) * -1f;
                }
                else
                {
                    gunflipper.x = 0.5f;
                    gunflipper.y = 0.5f;
                    move.flip.x = Mathf.Abs(Player.transform.localScale.x);
                    move.x = 0;
                    //playerflipper.x = Mathf.Abs(Player.transform.localScale.x);
                }
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
              //  playerflipper.y = Mathf.Abs(Player.transform.localScale.y);
                //Player.transform.localScale = playerflipper;
                transform.localScale = gunflipper;
                Instantiate(bulletPrefab, shotpoint.position, Quaternion.Euler(x, y, rotZ - 90));
            }

        }
    }
}


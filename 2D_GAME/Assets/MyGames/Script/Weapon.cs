using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public Text AmmoController;
    private int AmountAmmo;
    public AudioClip soundclip;
    public AudioSource soundscream;
    public float cooldown = 1f;

    private void Start()
    {
        
    }
    void Update()
    {
        cooldown -= Time.deltaTime;
        AmountAmmo = int.Parse(AmmoController.text);
        if (Input.GetButtonDown("Fire1") && this.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static && AmountAmmo > 0 && Time.timeScale == 1f && cooldown < 0)
        {           
            Shoot();
            soundscream.PlayOneShot(soundclip);
            cooldown = 1;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        AmountAmmo--;
        AmmoController.text = AmountAmmo.ToString();
    }
}

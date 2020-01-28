using UnityEngine;
using UnityEngine.UI;

public class AddAmmo : MonoBehaviour
{
    public Text AmmoController;
    private int ammo;
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ammo = int.Parse(AmmoController.text);
        if (collision.CompareTag("Player"))
        {
            ammo++;
            Destroy(gameObject);
        }
        AmmoController.text = ammo.ToString();
    }
}

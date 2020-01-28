using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.up * speed);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }
}

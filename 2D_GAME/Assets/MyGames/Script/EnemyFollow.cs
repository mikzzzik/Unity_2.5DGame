using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float stopdistance = 8f;
    public float maxrange = 30f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position) > stopdistance && Vector2.Distance(transform.position, player.position) < maxrange) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player.position) < stopdistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
    }
}

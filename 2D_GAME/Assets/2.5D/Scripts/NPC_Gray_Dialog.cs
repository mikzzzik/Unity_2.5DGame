using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Gray_Dialog : MonoBehaviour
{
    public NPCMove _npc;

    public GameObject _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _npc = gameObject.GetComponent<NPCMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, _player.transform.position) < 0.5f)
        {
            if (Input.GetAxisRaw("Open") == 1)
            {
                _npc._canmove = false;
            }
          
            

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon2D : MonoBehaviour
{
    public PlayerMove2D move;
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosPlayer = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && cooldown < 0)
        {
           // move.CanMove = false;
            //Shoot(rotZ, difference.x, difference.y);
            cooldown = 1;
        
        }
//        Debug.Log(mousePosPlayer);
    }
}

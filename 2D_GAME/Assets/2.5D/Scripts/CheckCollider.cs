using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollider : MonoBehaviour
{

    public Object_Follow_Mouse follower;
    private float x,y;
    private GameObject _text;
    public TextFlash _tf;
    public float _timer;
    void Start()
    {

        _timer = 0.2f;
        x = GetComponent<BoxCollider2D>().size.x;
        y = GetComponent<BoxCollider2D>().size.y;
        Debug.Log("Script's working");
        follower = GameObject.FindGameObjectWithTag("ObjectToFollow").GetComponent<Object_Follow_Mouse>();
        _text = GameObject.FindGameObjectWithTag("InfoBar");
        _tf = GameObject.FindGameObjectWithTag("InfoBar").GetComponent<TextFlash>();
        follower._canPlace = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        _timer -= Time.deltaTime;
         RaycastHit2D Box = Physics2D.BoxCast(transform.position,
                                new Vector2(x + 0.1f, y + 0.1f),
                                0,
                                new Vector2(0, 0));
                                             
        Debug.Log(Box.collider);
        if (_timer < 0)
        {
            if (Box.collider != null)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _text.GetComponent<TextFlash>()._begin = true;
                    _text.GetComponent<Text>().text = "You can't place";

                }
                follower._canPlace = false;
            }
            else
            {
                follower._canPlace = true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public GameObject _player;
    public float _speed;
    public bool _canmove;
    public Transform[] _point;
    public int _rPoint;
    public float _Timer;
    public float _StartTime;
    public Animator _mAnim;

    void Start()
    {
        _canmove = true;
        _Timer = _StartTime;
        _rPoint = Random.Range(0, _point.Length);
        _player = GameObject.FindGameObjectWithTag("Player");
        _mAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canmove)
        {
            transform.position = Vector2.MoveTowards(transform.position, _point[_rPoint].position, _speed * Time.deltaTime);
        }
      
        Debug.Log(transform.position);
        Debug.Log(_point[_rPoint].position);
        var x = transform.position.x - _point[_rPoint].position.x;
        var y = transform.position.y - _point[_rPoint].position.y;

        if (x > 0)
        {
            _mAnim.SetBool("Right", false);
            _mAnim.SetBool("Left", true);
        }
        else
        {
           _mAnim.SetBool("Right", true);
            _mAnim.SetBool("Left", false);
        }
            
        if (Vector2.Distance(transform.position, _point[_rPoint].position) < 0.2f)
        {
            if(_Timer <= 0)
            {
                _rPoint = Random.Range(0, _point.Length);
                _Timer = _StartTime;
            }
            else
            {
                _Timer -= Time.deltaTime;
            }
        }
        
    }
}

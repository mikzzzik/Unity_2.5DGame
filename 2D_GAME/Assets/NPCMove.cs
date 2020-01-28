using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public GameObject _player;
    public float _speed;
    public bool _move;
    public Transform[] _point;
    public int _rPoint;
    public float _Timer;
    public float _StartTime;

    void Start()
    {
        _Timer = _StartTime;
        _rPoint = Random.Range(0, _point.Length);
        _player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _point[_rPoint].position, _speed * Time.deltaTime);

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

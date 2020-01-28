using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextFlash : MonoBehaviour
{
    private Animator m_Animator;
    public bool _begin;
    void Start()
    {
        
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (!_begin)
        {
            m_Animator.SetBool("Flash", false);
        }
        if (_begin) { 
        m_Animator.SetBool("Flash", true);
        _begin = false;
        }

    }
}
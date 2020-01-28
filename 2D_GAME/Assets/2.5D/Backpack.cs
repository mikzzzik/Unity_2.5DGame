using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public GameObject _backpack;
    private bool _open;
    void Start()
    {
        _open = false;
       // _backpack = GameObject.FindGameObjectWithTag("Backpack");
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            _backpack.SetActive(false);
        }*/
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!_open)
            {
                _backpack.SetActive(true);
                _open = true;
            }
            else
            {
                _backpack.SetActive(false);
                _open = false;
            }
        }
    }
}

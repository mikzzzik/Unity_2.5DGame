using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObjectToPlace : MonoBehaviour
{
    
    public Text[] Item;
    public Object_Follow_Mouse _obj;
    public GameObject[] _itemtoplace;
    private int _num;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            _num = 1;
        }

        if (_num != 0)
        {
            var amountitemone = int.Parse(Item[_num].text);
            if (amountitemone != 0)
            {
                _obj.obj = _itemtoplace[_num];
                _obj._amount = Item[_num];
                _obj.gameObject.SetActive(true);
              
                // _obj.GetComponent<SpriteRenderer>().sprite = _itemtoplace[1].GetComponent<SpriteRenderer>().sprite;
            }
        }

        _num = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Object_Follow_Mouse : MonoBehaviour
{
    public GameObject obj;
    public Text _amount;
    private Transform player;
    public bool _inmouseobj;
    private GameObject newChild;
    public bool _canPlace; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _inmouseobj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inmouseobj)
        {
            _inmouseobj = true;
            newChild = Instantiate(obj, this.transform);
            newChild.GetComponent<BoxCollider2D>().enabled = false;
            newChild.AddComponent<CheckCollider>();
        }
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector2(mousePos.x, mousePos.y);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (Vector2.Distance(player.position, mousePos) < 3 && _canPlace)
            {
                Instantiate(obj, new Vector2(mousePos.x, mousePos.y), Quaternion.identity);
                var new_amount = int.Parse(_amount.text);
                new_amount--;
                _amount.text = new_amount.ToString();
                this.gameObject.SetActive(false);
                Destroy(newChild);
                _inmouseobj = false;
            }

            else if (Vector2.Distance(player.position, mousePos) >= 3)
            {
                Debug.Log("Distance more 3");   
            }

  
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(newChild);
            _inmouseobj = false;
            this.gameObject.SetActive(false);
            
        }

    }
}

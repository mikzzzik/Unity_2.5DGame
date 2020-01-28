using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextUpdate : MonoBehaviour
{
    public Text change_text = null;
    void Start()
    {
        change_text.text = "Hello world";
    }

    // Update is called once per frame

}

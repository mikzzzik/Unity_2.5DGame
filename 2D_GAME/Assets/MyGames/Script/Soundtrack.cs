using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundtrack : MonoBehaviour
{
    public GameObject Sound;


    // Update is called once per frame
    public void Check()
    {
        Debug.Log(this.GetComponent<Toggle>().isOn);
        if (this.GetComponent<Toggle>().isOn == true)
        {
            Sound.GetComponent<AudioSource>().Play();        
        }
        else if (this.GetComponent<Toggle>().isOn == false) 
        {
            Sound.GetComponent<AudioSource>().Stop(); 
        }
    }


}

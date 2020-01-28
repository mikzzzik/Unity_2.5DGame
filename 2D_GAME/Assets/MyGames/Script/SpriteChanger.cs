using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SpriteChanger : MonoBehaviour
{
    //public AudioClip sound;
//    public AudioClip soundclip;
//    public AudioSource soundscream;
    public Text ScoreControl;
//    public Text grivni;
    public Sprite mySprite;
    private int score;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        score = int.Parse(ScoreControl.text);
        if (score > 1)
        {
           
           // this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //    this.GetComponent<SpriteRenderer>().sprite = mySprite;
         //  soundscream.PlayOneShot(soundclip);
        }
    }
}

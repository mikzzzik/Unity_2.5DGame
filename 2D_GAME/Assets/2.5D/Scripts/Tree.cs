using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Transform player;

    public Text Wood_Amount;
    private GameObject _text;
    public TextFlash _tf;

    private int amount;
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hp = 10;
        Wood_Amount = GameObject.FindGameObjectWithTag("Woodamount").GetComponent<Text>();
        _text = GameObject.FindGameObjectWithTag("ProgressBar");
        _tf = GameObject.FindGameObjectWithTag("InfoBar").GetComponent<TextFlash>();
    }

    public void OnClick()
    {
        if ((Vector2.Distance(this.transform.position, player.position) < 2.5f)){
            Debug.Log("Click");
            hp--;
            if (hp == 0)
            {
                amount = int.Parse(Wood_Amount.text) + Random.Range(1, 6);
                Wood_Amount.text = amount.ToString();
                Destroy(gameObject);
               
            }
            _text.GetComponent<TextFlash>()._begin = true;
            _text.GetComponent<Text>().text = "Progress:" + hp + " / 10";
        }
    }
    public void OnEnter()
    {
        Debug.Log("Enter");
    }
    public void OnExit()
    {
        Debug.Log("Exit");
    }
    void Update()
    {
        
    }
}

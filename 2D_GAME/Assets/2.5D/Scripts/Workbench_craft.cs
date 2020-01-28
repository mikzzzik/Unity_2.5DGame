using UnityEngine.UI;
using UnityEngine;

public class Workbench_craft : MonoBehaviour
{
    //public int[] Item;
    public Text Text_Wood_Amount;
    private int Wood_amount;
    public Text[] Item_Text;
   
    void Start()
    {
        Debug.Log(Item_Text[1].text);
        Wood_amount = int.Parse(Text_Wood_Amount.text);
    }

    public void Craft(int index) 
    {
        switch (index)
        {
            case 1:
                if (Wood_amount >= 5)
                {
                    Wood_amount -= 5;
                    var amount_bench = int.Parse(Item_Text[1].text);
                    amount_bench++; 
                    Item_Text[1].text = (amount_bench).ToString();

                }               
                else
                    Debug.Log("You don't have enough resources");
                break;
        }
        Text_Wood_Amount.text = Wood_amount.ToString();

    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }*/
    }
}

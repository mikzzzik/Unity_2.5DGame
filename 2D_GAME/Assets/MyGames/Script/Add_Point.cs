using UnityEngine.UI;
using UnityEngine;

public class Add_Point : MonoBehaviour
{
    private int point;
    public Text pointtext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        point = int.Parse(pointtext.text);
        if (collision.CompareTag("Player"))
        {

            this.gameObject.SetActive(false);
            point++;
        }
        pointtext.text = point.ToString();
    }
}

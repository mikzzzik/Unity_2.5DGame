using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class MobileHealthController : MonoBehaviour
{
    public float playerHealth;
    public Text healthText;
    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");
        if (playerHealth == 0 ) 
            SceneManager.LoadScene("Game");
    }
}

using UnityEngine;


public class MobileDamageController : MonoBehaviour
{

    [SerializeField]  public float SpikeDamage;
    [SerializeField]  private MobileHealthController healthController;
                       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
         void Damage()
        {
            healthController.playerHealth   = healthController.playerHealth - SpikeDamage;
            healthController.UpdateHealth();
            this.gameObject.SetActive(false);
        }
    }
}

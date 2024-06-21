using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] Image healthBar;

    int maxHealth;

    private void Start()
    {
        maxHealth = health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 25;
            IsDead();
        }
    }

    void IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            healthBar.fillAmount = (float)health / maxHealth;
        }
    }
}

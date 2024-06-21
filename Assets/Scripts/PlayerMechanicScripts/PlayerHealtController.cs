using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtController : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] int health;

    int maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health -= 25;
            IsPlayerDead();
            UpdateHealthBar();
        }
    }

    void IsPlayerDead()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)health / maxHealth;
    }
}

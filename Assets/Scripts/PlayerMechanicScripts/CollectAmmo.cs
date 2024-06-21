using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponentInChildren<PlayerGunController>().bulletCount < 100)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponentInChildren<PlayerGunController>().bulletCount += 10;
            collision.gameObject.GetComponentInChildren<PlayerGunController>().UpdateBulletCount();
            
        }
    }
}

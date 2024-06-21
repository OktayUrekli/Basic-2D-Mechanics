using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    Rigidbody2D bulletRigidbody;

    [SerializeField] float force;

    Camera mainCamera;
    Vector3 mousePos;

    private void Start()
    {
        bulletRigidbody = gameObject.GetComponent<Rigidbody2D>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;

        bulletRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        Invoke("DestroyThisBullet", 1f);
    }

    void DestroyThisBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag!="Player")
        {
            DestroyThisBullet();
        }
    }


}
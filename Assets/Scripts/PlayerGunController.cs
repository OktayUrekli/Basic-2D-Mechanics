using TMPro;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    Camera mainCamera;
    Vector3 mousePos;
    Vector3 shootDirection;

    [SerializeField] float timeBetweenFiring;
    bool canFire;
    float timer;

    public int bulletCount;
    [SerializeField] TextMeshProUGUI bulletCountText;
    bool haveAmmo;


    private void Start()
    {
        bulletCount = 50;
        canFire = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        FindMousePos();
        CanShoot();
        Shoot();
        IsPlayerHasAmmo();
        
    }

    void FindMousePos()
    {
        if (mainCamera != null)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            SetRotationAndDirection();
        }
    }

    void SetRotationAndDirection()
    {
        shootDirection = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    void CanShoot()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenFiring)
            {
                canFire = true;
            }
        }
    }

    void IsPlayerHasAmmo()
    {
        if (bulletCount>0)
        {
            haveAmmo = true;
        }
        else
        {
            haveAmmo= false;
        }

        
    }

    public void UpdateBulletCount()
    {
        if (bulletCount >= 100)
        {
            bulletCount = 100;
        }
        bulletCountText.text=bulletCount.ToString();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && canFire && haveAmmo )
        {
            float bulletRotation = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, bulletRotation + 90));
            bulletCount--;
            UpdateBulletCount();
            timer = 0;
            canFire = false;
        }
    }

    






}
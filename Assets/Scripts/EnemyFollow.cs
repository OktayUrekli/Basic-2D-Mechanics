using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float rotZ = Mathf.Atan2(direction.y, direction.z) * Mathf.Deg2Rad;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}

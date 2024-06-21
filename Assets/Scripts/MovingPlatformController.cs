using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    [SerializeField] Transform pointA, pointB;
    [SerializeField] float speed;
    Vector3 targetPos;

    private void Start()
    {
        targetPos = pointA.position;
    }

    void Update()
    {
        PlatformMovement();
    }

    void PlatformMovement()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.05f)
        {
            targetPos = pointB.position;
        }
        if (Vector2.Distance(transform.position, pointB.position) < 0.05f)
        {
            targetPos = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

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
        if (player != null)
        {
            gameObject.transform.position = player.transform.position + offset;
            // new Vector2(player.transform.position.x + offset.x, player.transform.position.y + offset.y);
        }
    }
}
using UnityEngine;

public class LevelStartAndFinish : MonoBehaviour
{
    GameObject player;
    GameObject startPoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
    }

    private void Start()
    {
        SetPlayerAtStartPoint();
    }

    void SetPlayerAtStartPoint()
    {
        if (startPoint != null && player != null)
        {
            player.transform.position = startPoint.transform.position;
        }
    }


}
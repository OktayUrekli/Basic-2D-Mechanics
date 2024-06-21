using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{

    Rigidbody2D myRigidbody;

    float input_X_Axis, input_Y_Axis;
    Vector2 direction;

    [SerializeField] float speedMultiplier;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AxisInput();
        PlayerMovementWithRigidbody();
    }

    void AxisInput()
    {
        input_X_Axis = Input.GetAxis("Horizontal");
        input_Y_Axis = Input.GetAxis("Vertical");
        direction = new Vector2(input_X_Axis, input_Y_Axis).normalized;
    }


    void PlayerMovementWithRigidbody()
    {
        myRigidbody.velocity = direction * speedMultiplier * Time.deltaTime;
    }


}
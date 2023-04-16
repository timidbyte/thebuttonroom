using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform orientation;
    [SerializeField]
    private float speedFactor;
    [SerializeField]
    private float maxSpeed;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 1;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    }

    private void FixedUpdate()
    {
        AddForce();
        LimitSpeed();
    }

    private void AddForce()
    {
        rb.AddForce(moveDirection.normalized * speedFactor, ForceMode.Force);
    }

    private void LimitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = moveDirection.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}

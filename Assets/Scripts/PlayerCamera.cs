using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float sensetivity;

    [SerializeField]
    private Transform orientation;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        float dx = Input.GetAxis("Mouse X") * deltaTime * sensetivity;
        float dy = Input.GetAxis("Mouse Y") * deltaTime * sensetivity;
        yRotation += dx;
        xRotation -= dy;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

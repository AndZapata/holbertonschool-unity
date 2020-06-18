using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraOffset;
    public Transform playerTransform;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 5f;
    public float Smoothfactor = 1f;
    Quaternion camTurnAngle;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
          if (Input.GetMouseButton(1))
            camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
          cameraOffset = camTurnAngle * cameraOffset;
        }
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, Smoothfactor);
        if (rotateAroundPlayer)
            transform.LookAt(playerTransform);
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
  private Vector3 cameraOffset;
  public Transform playerTransform;
  public float rotationSpeed = 5f;
  Quaternion camTurnAngle;

  void Start()
  {
    cameraOffset = transform.position - playerTransform.position;
  }

  void LateUpdate()
  {
    if (Input.GetMouseButton(1))
    {
      camTurnAngle = Quaternion.Euler(Input.GetAxis("Mouse Y") * rotationSpeed, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
    cameraOffset = camTurnAngle * cameraOffset;
    Vector3 newPos = playerTransform.position + cameraOffset;
    transform.position = newPos;
    transform.LookAt(playerTransform);
  }
}

using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
  public Transform playerTransform;
  public float rotationSpeed = 100f;
  Quaternion camTurnAngle;
  public bool isInverted = false;
  float mouseX;
  float mouseY;
  public Toggle InvertedYMode;

  void Start()
  {
    if (InvertedYMode)
      isInverted = true;
  }

  void LateUpdate()
  {
    mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
    mouseY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * (isInverted ? -1 : 1);
    Vector3 dir = new Vector3(0, 2f, -5f);
    mouseY = Mathf.Clamp(mouseY, -20f, 20f);
    camTurnAngle = Quaternion.Euler(mouseY, mouseX, 0);
    transform.position = playerTransform.position + camTurnAngle * dir;
    transform.LookAt(playerTransform);
  }
}

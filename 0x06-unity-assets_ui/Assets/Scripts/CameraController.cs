using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
  public Transform playerTransform;
  public float rotationSpeed = 100f;
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
    Vector3 dir = new Vector3(0, 3f, -6f);
    mouseY = Mathf.Clamp(mouseY, -20f, 20f);
    Quaternion camTurnAngle = Quaternion.Euler(mouseY, mouseX, 0);
    transform.position = playerTransform.position + camTurnAngle * dir;
    transform.LookAt(playerTransform);
  }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
  public Transform playerTransform;
  public float rotationSpeed = 100f;
  public bool isInverted;
  float mouseX;
  float mouseY;

  void Start()
  {
    if (PlayerPrefs.GetInt("Inverted") == 1)
      isInverted = true;
    else
      isInverted = false;
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

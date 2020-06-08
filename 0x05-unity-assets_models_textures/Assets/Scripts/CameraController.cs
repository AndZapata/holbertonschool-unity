using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool lookAtPlayer = true;
    private Vector3 _cameraOffset;
    public Transform playerTransform;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 5f;

    public float Smoothfactor = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }
        Vector3 newPos = playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(playerTransform.position, newPos, Smoothfactor);
        if (lookAtPlayer || rotateAroundPlayer)
            playerTransform.LookAt(playerTransform);
    }
}

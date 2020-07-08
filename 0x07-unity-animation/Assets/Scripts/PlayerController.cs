using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float jump = 1.8f;
    public float speed = 12f;
    public float gravity = -20f;
    Transform playerPosition;
    Transform mainCamera;
    Vector3 vel;


    void Start()
    {
        playerPosition = GetComponent<Transform>();
        mainCamera = Camera.main.transform;
    }
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (controller.isGrounded && vel.y < 0)
            vel.y = -2f;
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
            vel.y = Mathf.Sqrt(jump * -2f * gravity);
        Vector3 CamForward = mainCamera.forward;
        Vector3 CamRight = mainCamera.right;
        CamForward.y = 0;
        CamRight.y = 0;
        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;
        Vector3 direction = (CamRight * horizontal) + (CamForward * vertical);
        controller.Move(direction * speed * Time.deltaTime);
        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
        if (playerPosition.position.y < -30f)
            playerPosition.position = new Vector3(0, 50, 0);
    }
}

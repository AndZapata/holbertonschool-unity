using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f * 2;
    public float jump = 1.8f;
    public float speed = 12f;
    public float turnSmoothTime = 0.1f;
    Transform mainCamera;
    Transform playerPosition;
    float turnSmoothVelocity;
    Vector3 vel;

    public Animator animator;
    bool fallingDown = false;
    int jumpHash = Animator.StringToHash("Jump");

    void Start()
    {
        playerPosition = GetComponent<Transform>();
        mainCamera = Camera.main.transform;
        // animator = this.GetComponent<Animator>();
    }
    public void Update()
    {
        if (controller.isGrounded && vel.y < 0)
            vel.y = 0f;
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            vel.y = Mathf.Sqrt(jump * -2f * gravity);
            animator.SetTrigger (jumpHash);
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
        if (playerPosition.position.y < -30f)
        {
            fallingDown = true;
            playerPosition.position = new Vector3(0, 50, 0);
            animator.SetBool("FallingDown", fallingDown);
        }
    }
}

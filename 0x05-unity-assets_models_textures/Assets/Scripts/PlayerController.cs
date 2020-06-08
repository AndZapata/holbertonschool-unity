using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float jump = 2.5f;
    public float speed = 12f;
    public float gravity = -10f * 2;
    Transform playerPosition;
    Vector3 vel;


    void Start()
    {
        playerPosition = GetComponent<Transform>();
    }
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (controller.isGrounded && vel.y < 0)
            vel.y = -2f;
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
            vel.y = Mathf.Sqrt(jump * -2f * gravity);
        Vector3 direction = (transform.right * horizontal) + (transform.forward * vertical);
        controller.Move(direction * speed * Time.deltaTime);
        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
        if (playerPosition.position.y < -30f)
        {
            playerPosition.position = new Vector3(0, 50, 0);
        }
    }
}

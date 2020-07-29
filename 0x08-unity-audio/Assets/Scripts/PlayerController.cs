using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Player variables
  public CharacterController controller;
  public float gravity = -9.81f * 2;
  public float jump = 1.8f;
  public float speed = 12f;
  Transform mainCamera;
  Transform playerPosition;
  Vector3 vel;

  // Animator variables
  public Animator animator;
  int jumpHash = Animator.StringToHash("Jump");
  int fallingHash = Animator.StringToHash("Falling");
  bool running = false;

  // Audio variables
  public AudioSource footSteps;
  public AudioClip grassFootStep;
  public AudioSource landingGrassFootStep;
  bool canPlayLanding = false;

  void Start()
  {
    playerPosition = GetComponent<Transform>();
    mainCamera = Camera.main.transform;
  }

  public void Update()
  {
    if (controller.isGrounded && vel.y < 0)
      vel.y = -2f;

    if (controller.isGrounded && Input.GetButtonDown("Jump"))
    {
      running = false;
      vel.y = Mathf.Sqrt(jump * -2f * gravity);
      animator.SetTrigger(jumpHash);
      if (playerPosition.position.y < -5f)
      {
        animator.SetTrigger(fallingHash);
      }
    }

    if (running == true)
      animator.SetBool("Run", true);
    else
      animator.SetBool("Run", false);

    Movement();

    if (playerPosition.position.y < -5f)
    {
      animator.SetTrigger(fallingHash);
      if (playerPosition.position.y < -40f)
      {
        running = false;
        playerPosition.position = new Vector3(0, 70, 0);
      }
    }
  }

  void Movement()
  {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    if (direction.magnitude >= 0.1f)
    {
      // Set animation bool
      running = true;

      // Audio controller
      if (controller.isGrounded)
      {
        footSteps.volume = Random.Range(0.8f, 1);
        footSteps.pitch = Random.Range(0.8f, 1.1f);
        footSteps.PlayOneShot(grassFootStep);
      }

      // Movement controller
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
      transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
      Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
      controller.Move(moveDir.normalized * speed * Time.deltaTime);
    }
    else
      running = false;
    vel.y += gravity * Time.deltaTime;
    controller.Move(vel * Time.deltaTime);
  }

  void OnTriggerEnter(Collider other)
  {
    landingGrassFootStep.Stop();
    if (other.tag == "Splat")
    {
      canPlayLanding = true;
      if (!landingGrassFootStep.isPlaying && canPlayLanding == true)
        StartCoroutine(PlayLandingSound());
    }
    if (other.tag == "Birds")
      FindObjectOfType<AudioManager>().Play("Birds");
    if (other.tag == "Crickets")
      FindObjectOfType<AudioManager>().Play("Crickets");
  }
  IEnumerator PlayLandingSound()
  {
    canPlayLanding = false;
    landingGrassFootStep.Play();
    yield return new WaitForSeconds(0.5f);
    canPlayLanding = true;
  }
}

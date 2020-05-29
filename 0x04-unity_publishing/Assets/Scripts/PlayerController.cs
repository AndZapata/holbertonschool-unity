using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public bool isFlat = true;
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    public GameObject joystick;

    public void Update()
    {
        if (health == 0)
        {
            winLoseBG.color = new Color32(129, 5, 7, 200);
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    public void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount > 0)
            {
                isFlat = false;
                joystick.gameObject.SetActive(true);
                float movH = CrossPlatformInputManager.GetAxis("Horizontal") * (speed * Time.deltaTime);
                float movY = CrossPlatformInputManager.GetAxis("Vertical") * (speed * Time.deltaTime);
                rb.AddForce(movH, 0, movY);
            }
            else
            {
                Vector3 tilt = Input.acceleration;
                if (isFlat)
                {
                    tilt = Quaternion.Euler(90, 0, 0) * tilt;
                    rb.AddForce(tilt);
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(0, 0, speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                rb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score = score + 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health = health - 1;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            winLoseBG.color = new Color32(4, 86, 79, 200);
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.white;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

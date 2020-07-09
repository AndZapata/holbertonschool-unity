using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator animator;
    public GameObject mainCam;
    public GameObject timer;
    public PlayerController playerScript;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).length < animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            timer.SetActive(true);
            playerScript.enabled = true;
            mainCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject timerUI;
    public GameObject winMenuUI;
    //public Text timerText;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().enabled = false;
            timerUI.SetActive(false);
            winMenuUI.SetActive(true);
            // timerText.color = Color.green;
            // timerText.fontSize = 100;
        }
    }
}

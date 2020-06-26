using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject timerUI;
    public GameObject winMenuUI;
    public Text FinalTime;
    public Text timerText;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().enabled = false;
            Win();
            // timerText.color = Color.green;
            // timerText.fontSize = 100;
        }
    }
    public void Win()
    {
        timerUI.SetActive(false);
        winMenuUI.SetActive(true);
        FinalTime.text = timerText.text;
    }
}

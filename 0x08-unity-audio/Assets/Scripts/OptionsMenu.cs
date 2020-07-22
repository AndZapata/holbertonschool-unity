using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertedYMode;
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == 1)
            InvertedYMode.isOn = true;
        else
            InvertedYMode.isOn = false;
    }
    
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void Apply()
    {
        if (InvertedYMode.isOn == true)
            PlayerPrefs.SetInt("Inverted", 1);
        else
            PlayerPrefs.SetInt("Inverted", 0);
        Back();
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}

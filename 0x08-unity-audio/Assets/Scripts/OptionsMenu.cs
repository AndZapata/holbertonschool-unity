using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertedYMode;

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
}

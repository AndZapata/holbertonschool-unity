using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioMixerSnapshot pauseSnap;
    public AudioMixerSnapshot unpauseSnap;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        unpauseSnap.TransitionTo(0.01f);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        pauseSnap.TransitionTo(0.01f);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
    
    public void Options()
    {
        Resume();
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
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

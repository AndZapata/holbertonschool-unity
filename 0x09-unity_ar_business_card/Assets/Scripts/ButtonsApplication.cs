using UnityEngine;

public class ButtonsApplication : MonoBehaviour
{
    public void Twitter() {
        Application.OpenURL("https://twitter.com/AndZapata1");
    }
    public void Github() {
        Application.OpenURL("https://github.com/AndZapata");
    }
    public void Email() {
        Application.OpenURL("mailto:andzapata514@gmail.com");
    }
    public void LinkedIn() {
        Application.OpenURL("https://www.linkedin.com/in/paula-andrea-gutierrez-zapata/");
    }
}

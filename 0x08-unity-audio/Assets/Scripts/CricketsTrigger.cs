using UnityEngine;

public class CricketsTrigger : MonoBehaviour
{
    public GameObject player;
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            FindObjectOfType<AudioManager>().Stop("Crickets");
    }
}

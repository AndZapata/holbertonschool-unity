using UnityEngine;

public class BirdsTrigger : MonoBehaviour
{
    public GameObject player;
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            FindObjectOfType<AudioManager>().Stop("Birds");
    }
}

using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Drag your AudioSource here in the Inspector.

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is the player.
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Start the audio when the player enters the zone.
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop the audio when the player leaves the zone.
            }
        }
    }
}

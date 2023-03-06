using UnityEngine;

public class Key : MonoBehaviour
{
    // A reference to the player's key tracker
    public KeyTracker playerKeyTracker;

    // The audio clip to play when the key is picked up
    public AudioClip keyPickupClip;

    // The audio source component to play the audio clip
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        // Get the audio source component attached to this game object
        audioSource = GetComponent<AudioSource>();
    }

    // Detects when the player presses the F key while looking at the key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerLookingAtKey())
        {
            // Find the child object named "Indestructible"
            Transform indestructibleChild = transform.Find("Indestructible");

            // Unparent the indestructible child from the key
            indestructibleChild.parent = null;

            // The player picked up the key, so destroy it
            Destroy(gameObject);

            // Update the player's key tracker to indicate that they now have the key
            playerKeyTracker.HasKey = true;

            // Play the audio clip for key pickup
            audioSource.PlayOneShot(keyPickupClip);
        }
    }

    // Returns true if the player is looking at the key
    bool IsPlayerLookingAtKey()
    {
        // Get the direction from the player to the key
        Vector3 direction = transform.position - Camera.main.transform.position;

        // If the angle between the camera's forward direction and the direction to the key is less than 45 degrees, the player is looking at the key
        return Vector3.Angle(Camera.main.transform.forward, direction) < 45f;
    }
}

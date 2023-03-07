using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public KeyTracker keyTracker;
    public AudioClip lockedClip;

    // The scene to load when the door is unlocked
    public string nextSceneName;

    private bool isLocked = true;

    private void Start()
    {
        // Check if the key tracker has the key
        if (keyTracker.HasKey)
        {
            // The door is unlocked
            isLocked = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked)
        {
            // Load the next scene if the door is unlocked
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // Play the locked audio clip if the door is locked
            AudioSource.PlayClipAtPoint(lockedClip, transform.position);
        }
    }
}

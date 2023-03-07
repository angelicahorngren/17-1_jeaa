using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    public string sceneName; 
    public KeyCode triggerKey = KeyCode.F; 
    public float switchDelay = 5f; 
    public AudioClip audioClip;

    private bool isPlayerInRange = false; 

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(triggerKey))
        {
            KeyTracker keyTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyTracker>();
            if (keyTracker != null && keyTracker.HasKey)
            {
                Invoke("SwitchScene", switchDelay);
            }
            else
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null && audioClip != null)
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                }
            }
        }
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}

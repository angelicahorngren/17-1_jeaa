using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    public AudioClip heyClip;
    public float triggerRadius = 1f;
    public KeyCode triggerKey = KeyCode.F; 
    public GameObject player;

    private bool isPlayerInRange = false; 

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(triggerKey))
        {
            AudioSource.PlayClipAtPoint(heyClip, transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}

using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    public AudioClip heyClip;
    public float triggerRadius = 1f;
    public KeyCode triggerKey = KeyCode.F; 
    public GameObject player;
    //public GameObject screenFader;

    private bool isPlayerInRange = false; 

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(triggerKey))
        {
            //screenFader.GetComponent<ScreenFader>().FadeIn();  
            AudioSource.PlayClipAtPoint(heyClip, transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
        //screenFader.GetComponent<ScreenFader>().FadeIn();  
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

using UnityEngine;

namespace SG
{
    public class ResetHealth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.currentHealth = 100;
            }
        }
    }
}

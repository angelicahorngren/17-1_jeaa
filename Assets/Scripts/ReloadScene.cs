using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class ReloadScene : MonoBehaviour
    {
        public float delay = 6f; 

        private void Update()
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats != null && playerStats.currentHealth == 0)
            {
                Invoke("Reload", delay); 
            }
        }

        private void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class ReloadScene : MonoBehaviour
    {
        private void Update()
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats != null && playerStats.currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

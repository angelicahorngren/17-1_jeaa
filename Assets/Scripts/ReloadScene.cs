using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class ReloadScene : MonoBehaviour
    {
        public float delay = 10f; 

        public GameObject screenFader;

            private void Update()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null && playerStats.currentHealth == 0)
        {
            Invoke("Reload", delay);
            screenFader.GetComponent<ScreenFader>().FadeIn();
        }
    }

    private void Reload()
    {
        Debug.Log("Reload");
        screenFader.GetComponent<ScreenFader>().FadeOut();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


}

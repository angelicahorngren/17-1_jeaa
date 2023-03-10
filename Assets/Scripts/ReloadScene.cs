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
            if(screenFader != null){
                screenFader.GetComponent<ScreenFader>().FadeIn();  
            }
        }
    }

    private void Reload()
    {
        screenFader.GetComponent<ScreenFader>().FadeOut();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


}

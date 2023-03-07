using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Bedroom");
    }

    public void QuitGame(){
        Application.Quit();
    }
    
    public void CloseMenu(){
        Time.timeScale = 1f;
    }

    public void Pause(){
        Time.timeScale = 0f;
    }
}

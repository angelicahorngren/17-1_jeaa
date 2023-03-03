using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextScene;
    void onTriggerEnter(Collider other)
    {
        if (other.name == "Player"){
            
            SceneManager.LoadScene(nextScene);
        }

    }

}

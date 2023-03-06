using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDream : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
    // Start is called before the first frame update

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject == player /*&& player.key == true*/){
            //open door
            //smoke animation
            //Wait a few seconds
            SceneManager.LoadScene(sceneName);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    /*private bool entered = false;
    public GameObject screenFader;
    */
    public string sceneName; // the name of the scene you want to load
    public GameObject player; // reference to the player GameObject
    //public int xPos;
    //public int yPos;
    //public int zPos;


    /*void Update(){
        if(entered){
            screenFader.GetComponent<ScreenFader>().FadeIn(); 
        }
    }
    */
   public void OnCollisionEnter(Collision other)
{
    //entered = true;
    Debug.Log("Test");
    if (other.gameObject == player)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName); // load the specified scene
        //other.transform.position = new Vector3(xPos, yPos, zPos);
    }
}

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneName; // the name of the scene you want to load
    public GameObject player; // reference to the player GameObject

   private void OnCollisionEnter(Collision other)
{
    if (other.gameObject == player)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName); // load the specified scene
    }
}

}

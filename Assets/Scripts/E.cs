using UnityEngine;
using System.Collections;

public class E : MonoBehaviour {

    public float timeToExit = 20f;

    void Start () {
        StartCoroutine(ExitAfterTime(timeToExit));
    }

    IEnumerator ExitAfterTime(float time) {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}

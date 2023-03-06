using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image panel;

    private float fadeSpeed = 0.002f;

    private void Start()
    {
        panel = GetComponentInChildren<Image>();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1));
        Debug.Log("FadeIn");
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0));
        Debug.Log("FadeOut");

    }

    private IEnumerator Fade(float targetAlpha)
    {
        panel.raycastTarget = true;
        while (!Mathf.Approximately(panel.color.a, targetAlpha))
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, Mathf.MoveTowards(panel.color.a, targetAlpha, fadeSpeed * Time.deltaTime));
            yield return null;
        }
        panel.raycastTarget = false;
    }

}

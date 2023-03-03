using System.Collections;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float duration = 1.0f;
    private Material material;

    private void Start()
    {
        MeshRenderer meshRenderer = transform.Find("Stylized_Fish_Model").GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startTime = Time.time;
        float startAlpha = material.color.a;

        while (Time.time < startTime + duration)
        {
            Debug.Log("Fading out...");
            
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(startAlpha, 0.0f, t);

            Color color = material.color;
            color.a = alpha;
            material.color = color;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}

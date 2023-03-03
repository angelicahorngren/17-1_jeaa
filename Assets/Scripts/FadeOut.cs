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

public void StartDissolve()
{
    // Disable collider to prevent further interactions with the player
    Collider collider = GetComponent<Collider>();
    if (collider != null)
    {
        collider.enabled = false;
    }

    // Play particle system
    ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
    if (particleSystem != null)
    {
        particleSystem.Play();
    }

    // Destroy the game object after a delay
    Destroy(gameObject, duration);
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

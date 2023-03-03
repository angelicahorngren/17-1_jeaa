using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class Interactable : MonoBehaviour
    {
        public string interactableText = "Press F to interact";
        public Text interactionText;
        public float interactionDistance = 3f;

        private bool isInRange = false;

        private void Start()
        {
            interactionText.enabled = false;
        }

        private void Update()
        {
            if (isInRange && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interacting with " + gameObject.name);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                float distance = Vector3.Distance(other.transform.position, transform.position);
                if (distance <= interactionDistance)
                {
                    isInRange = true;
                    ShowText();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = false;
                HideText();
            }
        }

        private void ShowText()
        {
            interactionText.enabled = true;
            interactionText.text = interactableText;
        }

        private void HideText()
        {
            interactionText.enabled = false;
        }
    }
}

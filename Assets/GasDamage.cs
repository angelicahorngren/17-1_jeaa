using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class GasDamage : MonoBehaviour
    {
        private int damage = 1;

        private void Start()
        {
            StartCoroutine(DealDamage());
        }

        private IEnumerator DealDamage()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.15f);
                PlayerStats playerStats = FindObjectOfType<PlayerStats>();
                if (playerStats != null)
                {
                    Debug.Log("Player found within range.");
                    playerStats.TakeDamage(damage);
                }
            }
        }

    }
}

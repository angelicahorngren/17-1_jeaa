using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class ProjectileCollision : MonoBehaviour
    {
        public int damage = 25;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();

                if (playerStats != null)
                {
                    playerStats.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

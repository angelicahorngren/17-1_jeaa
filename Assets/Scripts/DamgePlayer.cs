using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class DamgePlayer : MonoBehaviour
    {

        private int damage = 25;


        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();


            if (playerStats != null)
            {
                if (this.tag == "AI Bot")
                {
                    playerStats.TakeDamage(damage, true);
                }
                else
                {
                    playerStats.TakeDamage(damage);
                }

            }
        }
    }
}

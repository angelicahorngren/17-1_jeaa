using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class GasDamage : MonoBehaviour
    {
        public CreateObject createObject;

        //public GameObject soundBox;

        public GameObject player;

        public PlayDeathSound playDeathSound;

        private PlayerStats playerStats;

        private int damage = 1;

        public void Start()
        {
            StartCoroutine(DealDamage());
            playerStats = player.GetComponent<PlayerStats>();
            //playDeathSound = soundBox.GetComponent<PlayDeathSound>();
        }

        public IEnumerator DealDamage()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.15f);
                if (playerStats != null && playerStats.currentHealth > 0)
                {
                    playerStats.TakeDamage(damage, true);
                    if(playerStats != null && playerStats.currentHealth <= 0 && !createObject.hasSpawned){
                        Debug.Log("SOUND PLAYED");
                        playDeathSound.PlaySound();
                    }
                }
            }
        }

    }
}

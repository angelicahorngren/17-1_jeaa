using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class KillPlayer : MonoBehaviour
    {
        public GameObject player;
        private PlayerStats playerStats;

        public void Start()
        {
            playerStats = player.GetComponent<PlayerStats>();
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("HIT!");
            playerStats.currentHealth = 0;
        }
    }
}

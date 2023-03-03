using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG{
    public class TrapSound : MonoBehaviour
    {
        public AudioClip[] objectSounds;

        private AudioSource audioSource; 

        bool audioPlayed = false;

        public GameObject player;

        private PlayerStats playerStats;

        //public bool trapDeath = false;


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
            playerStats = player.GetComponent<PlayerStats>();
        }

        void OnTriggerEnter(Collider other)
        {
            playerStats.trapDeath = true;
            if (!audioPlayed){
                int randomIndex = Random.Range(0, objectSounds.Length);
                audioSource.clip = objectSounds[randomIndex]; 
                audioSource.Play(); 
                audioPlayed = true;
            }
        }

    }
}

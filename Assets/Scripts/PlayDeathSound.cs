using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class PlayDeathSound : MonoBehaviour
    {

        public GameObject player;

        public float delay = 6f;

        public AudioClip[] objectSounds;

        private AudioSource audioSource; 

        bool audioPlayed = false;
 

        private void Start()
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.playOnAwake = false;
                
                //playerStats = player.GetComponent<PlayerStats>();
            }

        private void Update()
        {
            /*PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats.currentHealth == 0){
                int randomIndex = Random.Range(0, objectSounds.Length);
                audioSource.clip = objectSounds[randomIndex]; 
                audioSource.Play(); 
                audioPlayed = true;
            }
            */
        }

        private void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void PlaySound(){
            int randomIndex = Random.Range(0, objectSounds.Length);
            audioSource.clip = objectSounds[randomIndex]; 
            audioSource.Play(); 
            audioPlayed = true;
        }
    }
}

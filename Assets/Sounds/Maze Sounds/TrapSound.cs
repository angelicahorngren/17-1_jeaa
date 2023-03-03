using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSound : MonoBehaviour
{
    public AudioClip[] objectSounds;

    private AudioSource audioSource; 

    bool audioPlayed = false;

    bool trapDeath = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        trapDeath = true;
        if (!audioPlayed && trapDeath){
            int randomIndex = Random.Range(0, objectSounds.Length);
            audioSource.clip = objectSounds[randomIndex]; 
            audioSource.Play(); 
            audioPlayed = true;
        }
    }

}


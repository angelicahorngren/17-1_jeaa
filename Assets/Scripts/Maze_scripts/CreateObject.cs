using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public bool hasSpawned = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned)
        {
            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
            hasSpawned = true;
        }
    }
}

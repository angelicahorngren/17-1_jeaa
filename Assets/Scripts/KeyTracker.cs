using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    // A bool indicating whether the player has the key or not
    public bool HasKey { get; set; }

    // Use this for initialization
    void Start()
    {
        // The player does not have the key at the start of the game
        HasKey = false;
    }
}

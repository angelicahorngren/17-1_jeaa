using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    public bool HasKey { get; set; }

    void Start()
    {
        HasKey = false;
    }
}

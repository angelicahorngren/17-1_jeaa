using UnityEngine;

public class Key : MonoBehaviour
{
    
    public KeyTracker playerKeyTracker;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerLookingAtKey())
        {
            Destroy(gameObject, 5f);

            playerKeyTracker.HasKey = true;
        }
    }

    // Returns true if the player is looking at the key
    bool IsPlayerLookingAtKey()
    {
        // Get the direction from the player to the key
        Vector3 direction = transform.position - Camera.main.transform.position;

        // If the angle between the camera's forward direction and the direction to the key is less than 45 degrees, the player is looking at the key
        return Vector3.Angle(Camera.main.transform.forward, direction) < 45f;
    }
}

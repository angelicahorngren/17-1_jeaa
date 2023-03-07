using UnityEngine;

public class Key : MonoBehaviour
{
    
    public KeyTracker playerKeyTracker;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerLookingAtKey())
        {
            Destroy(gameObject, 1f);

            playerKeyTracker.HasKey = true;
        }
    }


    bool IsPlayerLookingAtKey()
    {
 
        Vector3 direction = transform.position - Camera.main.transform.position;
        return Vector3.Angle(Camera.main.transform.forward, direction) < 45f;
    }
}

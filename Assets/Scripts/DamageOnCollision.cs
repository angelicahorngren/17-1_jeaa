using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damage = 10f; 

    private void OnCollisionEnter(Collision collision)
    {
        //check if collision is with player
        if (collision.gameObject.CompareTag("Player"))
        {/*
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            //if player is not dead, apply damage
            if (playerHealth != null && != 0f)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }*/
        }
        else if (collision.gameObject.CompareTag("friend"))
        {
            //do nothing if it hits the boss
        }
        else
        {
            // If the collision object is not a friend, destroy the projectile
            Destroy(gameObject);
        }
    }
}

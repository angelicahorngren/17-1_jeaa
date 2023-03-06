using UnityEngine;
using System.Collections;

namespace SG{

public class friend : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab; //prefab for the projectiles

    public float followDistance = 15f;  
    public float stopDistance = 10f;  
    public float startFollowDistance = 30f;
    public float speed = 0.1f;
    public float hoverHeight = 10f; //boss hover height
    public float attackDelay = 1.0f; //delay between attacks
    public float projectileSpeed = 5f; //speed of the projectiles
    private PlayerStats playerStats;

    public int health = 100; // boss's health

    private bool isAttacking = false; //flag to indicate if the boss is attacking
    private float attackTimer = 0.0f; //keep track of attack delay
    public ParticleSystem dissolveEffect;

  void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Friend");
        playerStats = player.GetComponent<PlayerStats>();
        dissolveEffect = transform.Find("DissolveEffect").GetComponent<ParticleSystem>();

    }

  void Update()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (health <= 0)
        {
            //handle the boss's death
            DestroyFriend();
           
            //Destroy(gameObject);
        }

        //if player within range and boss not already attacking
        else if (playerStats.currentHealth > 10 && distance <= stopDistance && !isAttacking)
        {
            isAttacking = true;

            //start attack timer
            attackTimer = attackDelay;
        }

        if (isAttacking)
        {
            //decrement the attack timer
            attackTimer -= Time.deltaTime;

            //if the attack time is over
            if (attackTimer <= 0.0f)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position + Vector3.up * hoverHeight, Quaternion.identity);
                projectile.layer = LayerMask.NameToLayer("FriendProjectiles");
                projectile.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

                //get distance between the boss and the player
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                //get direction to the player's head
                Vector3 playerHeadPosition = player.GetComponent<CapsuleCollider>().bounds.max;
                Vector3 direction = (playerHeadPosition - projectile.transform.position).normalized;

                //sets velocity towards the player's head
                projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed * distanceToPlayer;

                //reset attack timer
                attackTimer = attackDelay;

                isAttacking = false;
            }
        }

        //if player is within range to follow, but not within range to stop
        else if (distance <= startFollowDistance && distance > stopDistance)
        {
            //move the boss towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            
            transform.LookAt(player.transform);

            //hover above ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + hoverHeight, transform.position.z);
            }
        }
    }
        public void TakeDamage(int damage)
    {
        Debug.Log("Friend takes " + damage + " damage.");

        health -= damage;
    }

public void DestroyFriend()
{
    // Disable the collider and renderer of the friend object
    GetComponent<Collider>().enabled = false;
    GetComponent<Renderer>().enabled = false;

    // Play the dissolve particle effect
    ParticleSystem dissolveParticle = Instantiate(dissolveEffect, transform.position + Vector3.up * 2f, Quaternion.identity);
    dissolveParticle.Play();

    // Destroy the friend object after 5 seconds
    Destroy(gameObject, 5f);

    // Destroy the dissolve particle effect after 5 seconds
    Destroy(dissolveParticle.gameObject, 5f);
}

private IEnumerator DisplayParticleEffect(ParticleSystem particle, float duration)
{
    // Wait for the friend object to be destroyed
    yield return new WaitForSeconds(duration);

    // Play the dissolve particle effect again
    particle.Play();

    // Destroy the particle effect after 5 seconds
    Destroy(particle.gameObject, 5f);
}






}

}

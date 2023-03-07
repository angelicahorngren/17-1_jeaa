using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class BossAttack : MonoBehaviour
    {
        public int attackDamage = 20;
        public Vector3 attackOffset;
        public float attackRange = 1f;
        public LayerMask attackMask;
        private SphereCollider bossCollider;

void Start()
{
    bossCollider = GetComponent<SphereCollider>();
    bossCollider.radius = attackRange;
}


public void Attack()
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");
PlayerStats playerStats = player.GetComponent<PlayerStats>();

    Debug.Log("Boss Attack!");

    Vector3 pos = transform.position;
    pos += transform.right * attackOffset.x;
    pos += transform.up * attackOffset.y;

    if (bossCollider.bounds.Contains(playerStats.transform.position))
    {
        Debug.Log("Player hit!");
        playerStats.TakeDamage(attackDamage);
    }
}


        private bool IsPlayerWithinRange(Vector3 playerPos)
        {
            float distance = Vector3.Distance(transform.position, playerPos);
            return (distance <= attackRange);
        }
    }
}

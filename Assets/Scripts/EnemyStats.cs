using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;
    public GameObject keyPrefab; 

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        maxHealth = SetMaxHeathFromHealthLevel();
        currentHealth = maxHealth;
    }

    private int SetMaxHeathFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        animator.Play("Defence 2");

        if (currentHealth <= 0)
        {
            //animator.speed = -1f;
            animator.SetTrigger("Dead");

            GameObject key = Instantiate(keyPrefab, transform.position, Quaternion.identity);

           // Destroy(gameObject);
        }
    }
}

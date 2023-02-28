using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SG
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public HealthBar healthBar;
        AnimaterHandler animaterHandler;

        private void Awake()
        {
            animaterHandler = GetComponentInChildren<AnimaterHandler>();
        }

        void Start()
        {
            maxHealth = SetMaxHeathFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

        }

        private int SetMaxHeathFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }


        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);
            
          
            animaterHandler.PlayTargetAnimation("Take Damage", true);
           

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animaterHandler.PlayTargetAnimation("Death_01", true);
            }
        }

        public void TakeDamage(int damage, bool enemy= true)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);


            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animaterHandler.PlayTargetAnimation("Death_01", true);
            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 2; // Maximum health of the boss
    private int currentHealth; // Current health of the boss

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;

            // Check if the boss has been destroyed
            if (currentHealth <= 0)
            {
                // Perform any additional logic when the boss is destroyed (e.g., play an explosion animation, trigger an event, etc.)
                DestroyBoss();
            }
        }
    }

    void DestroyBoss()
    {
        // Perform any cleanup or destruction logic here (e.g., play a death animation, drop items, etc.)
        Destroy(gameObject); // Destroy the boss object
    }
}

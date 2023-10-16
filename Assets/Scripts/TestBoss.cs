using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Enemy movement speed
    public float collisionDisableDelay = 1.0f; // Delay before re-enabling the collider
    public string playerTag = "Player"; // Tag of the player to follow

    private Transform playerTransform; // Reference to the player's transform
    private Rigidbody2D rb; // Rigidbody2D reference
    private SpriteRenderer spriteRenderer; // Reference to the enemy's SpriteRenderer
    private Collider2D enemyCollider; // Reference to the enemy's Collider2D

    private int bulletsHitCount = 0; // Number of bullets that hit the boss
    private bool isDead = false; // Flag to track if the boss is already dead

    public int bulletsToDestroyBoss = 15;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();

        // Find the player's transform based on their tag (assuming the player has the "Player" tag)
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found with tag: " + playerTag);
        }
    }

    private void Update()
    {
        if (playerTransform != null && !isDead)
        {
            // Calculate the movement direction towards the player
            Vector3 movementDirection = (playerTransform.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            // Flip the enemy sprite based on the movement direction
            spriteRenderer.flipX = (movementDirection.x < 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isDead)
        {
            // Increment the hit count
            bulletsHitCount++;

            // Check if the boss has been hit by the required number of bullets (2 in this case)
            if (bulletsHitCount >= bulletsToDestroyBoss)
            {
                // Call a method to handle boss death (e.g., play a death animation, trigger an event, etc.)
                Die();
            }
        }
    }

    private void Die()
    {
        // Add any logic you want to handle the boss's death here
        // For example, you can play a death animation, trigger an event, or destroy the boss object
      
        Destroy(gameObject);

        // Set the flag to prevent further collisions and destruction
        isDead = true;
    }
}

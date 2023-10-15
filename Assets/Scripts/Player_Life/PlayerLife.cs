using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 initialPosition;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Trap") || 
            collision.gameObject.CompareTag("Boss"))
        {
            Die();
            if (HealthManager.health <= 0)
            {
                // Player has no health left, restart the game
                RestartGame();
            }
            else
            {
                // Reset player position and any other respawn logic
                Respawn();
            }

        }
      
    }

        private void Respawn()
    {
        // Reset player position to the starting position
        transform.position = new Vector3(0, 0, 0);
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Die()
    {
        // Subtract health
        HealthManager.health--;

        // Update the health bar
        HealthManager.Instance.UpdateHealthBar();

        //Set the animation trigger here for death

    }
}
 
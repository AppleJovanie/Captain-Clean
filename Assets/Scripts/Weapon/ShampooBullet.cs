using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShampooBullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HeadLice"))// Change to tag in enemey
        {
            // Destroy objects tagged as "Trap"
            Destroy(collision.gameObject);
        }

        // Always destroy the bullet
        Destroy(gameObject);
    }
}

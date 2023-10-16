using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Impetigo") || 
            collision.gameObject.CompareTag("Scabies") ||
            collision.gameObject.CompareTag("AthleteFoot"))
        {
           
            Destroy(collision.gameObject);
        }

        // Always destroy the bullet
        Destroy(gameObject);
    }
}
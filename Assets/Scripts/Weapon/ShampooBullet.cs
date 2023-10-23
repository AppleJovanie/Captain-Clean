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
        if (collision.gameObject.CompareTag("HeadLice")||
            collision.gameObject.CompareTag("BossLice"))
        {
            Destroy(collision.gameObject); // Destroy objects tagged as "HeadLice"
        }
    

        // Always destroy the bullet
        Destroy(gameObject);
    }
}

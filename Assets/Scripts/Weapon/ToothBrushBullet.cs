using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrushBullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cavity"))// Change to tag in enemey
        {

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}

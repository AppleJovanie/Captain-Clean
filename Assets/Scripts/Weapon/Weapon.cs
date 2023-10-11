using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet GameObject.
    public Transform firePoint; // The position from which bullets are fired.
    public float bulletSpeed = 10f; // Speed of the bullets.

    // Add more variables for controlling firing rate, bullet damage, etc., if needed.

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Customize "Fire1" to your input settings.
        {
            Shoot(); // Call the Shoot method when the fire button is pressed.
        }
    }
    void Shoot()
    {
        // Create a new bullet at the firePoint's position and rotation.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the Rigidbody2D component of the bullet to set its velocity.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity to move it forward.
        rb.velocity = transform.up * bulletSpeed;
    }
}

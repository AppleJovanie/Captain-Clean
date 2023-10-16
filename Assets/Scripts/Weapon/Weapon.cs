using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int totalWeapons = 1;

    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    public Transform shootingPointer;
    public GameObject[] shootingObjects; // An array of different bullets or shooting objects
    public float bulletSpeed = 3;
    public float cooldownDuration = 1.0f;
    private float lastShotTime;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PrevWeapon();
        }
    }

    public void SwitchWeapon()
    {
        if (currentWeaponIndex < totalWeapons - 1)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }
    }

    public void PrevWeapon()
    {
        if (currentWeaponIndex > 0)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }
    }

    public void TryToShoot()
    {
        if (Time.time - lastShotTime < cooldownDuration)
            return;

        // Check if there are shooting objects available for the current weapon
        if (currentWeaponIndex < shootingObjects.Length && shootingObjects[currentWeaponIndex] != null)
        {
            var bullet = Instantiate(shootingObjects[currentWeaponIndex], shootingPointer.position, transform.rotation);

            // Calculate the direction from the player to the shootingPointer
            Vector2 shootDirection = (shootingPointer.position - transform.position).normalized;

            // Set the velocity of the bullet to shoot horizontally
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletSpeed, 0);

            lastShotTime = Time.time;
        }
    }
 
}

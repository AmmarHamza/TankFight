using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    // The bullet prefab
    public GameObject bulletPrefab;

    // The size of the pool
    public int poolSize = 10;

    // The list of bullets
    private List<GameObject> bullets;

    public Transform firepoint;

    AudioSource bulletSound;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize the list of bullets
        bullets = new List<GameObject>();

        // Create the pool of bullets and set them inactive
        for (int i = 0; i < poolSize; i++)
        {
            // Instantiate a bullet from the prefab
            GameObject bullet = Instantiate(bulletPrefab);

            // Set the bullet inactive
            bullet.SetActive(false);

            // Add the bullet to the list
            bullets.Add(bullet);
        }
    }
    private void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        InvokeRepeating("Shoot", 2.5f, 1.5f);
    }
    void Shoot()
    {
        for (int i = 0;i < poolSize;i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].SetActive(true);
                bullets[i].transform.position = firepoint.position;
                bulletSound.Play();
                break;
            }
        }
    }
}

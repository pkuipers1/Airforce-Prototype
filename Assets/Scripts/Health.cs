using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth;

    [SerializeField] public static float playerHealth;
    [SerializeField] public static bool playerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag(("Player")))
        {
            playerHealth = Mathf.RoundToInt(currentHealth);
        }
    }
}

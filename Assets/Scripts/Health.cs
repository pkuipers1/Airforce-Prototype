using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    
    [Header("Health Variables")]
    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth;
    
    public static float playerHealth;
    public static bool playerSpawned;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        playerSpawned = true;
        
        if (gameObject.CompareTag(("Player")))
        {
            playerHealth = Mathf.RoundToInt(currentHealth);
        }
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

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}

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

    private AudioSource audioSource;
    [SerializeField] public AudioClip hitSound;
    
    public static float playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        audioSource = gameObject.GetComponent<AudioSource>();
        
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

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        audioSource.PlayOneShot(hitSound);
    }
}

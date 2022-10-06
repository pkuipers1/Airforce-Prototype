using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    public GameObject[] smokeEffects;

    [Header("Health Variables")]
    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth;

    private AudioSource audioSource;
    [SerializeField] public AudioClip hitSound;
    [SerializeField] public AudioClip deathSound;
    
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

        DisableSmoke();
        smokeEffects[0].SetActive(true);
        smokeEffects[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(deathSound.name);
        if (currentHealth <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(deathSound);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag(("Player")))
        {
            playerHealth = Mathf.RoundToInt(currentHealth);
        }

        if (playerHealth <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(deathSound);
            SceneManager.LoadScene(2);
        }

        if (currentHealth <= ((maxHealth / 10) * 8) && currentHealth > ((maxHealth / 10) * 6))
        {
            DisableSmoke();
            smokeEffects[2].SetActive(true);
            smokeEffects[3].SetActive(true);
        }
        else if (currentHealth <= ((maxHealth / 10) * 6) && currentHealth > ((maxHealth / 10) * 4))
        {
            DisableSmoke();
            smokeEffects[4].SetActive(true);
            smokeEffects[5].SetActive(true);
        }
        else if (currentHealth <= ((maxHealth / 10) * 4) && currentHealth > ((maxHealth / 10) * 2))
        {
            DisableSmoke();
            smokeEffects[6].SetActive(true);
            smokeEffects[7].SetActive(true);
        }
        else if (currentHealth <= ((maxHealth / 10) * 2) && currentHealth > ((maxHealth / 10) * 1))
        {
            DisableSmoke();
            smokeEffects[8].SetActive(true);
            smokeEffects[9].SetActive(true);
        }
    }

    void DisableSmoke()
    {
        foreach (var smoke in smokeEffects)
        {
            smoke.SetActive(false);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        audioSource.PlayOneShot(hitSound);
    }
}

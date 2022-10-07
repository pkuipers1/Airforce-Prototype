using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    public ParticleSystem smoke1;
    public ParticleSystem smoke2;

    private AudioSource audioSource;
    
    [SerializeField] public AudioClip hitSound;
    [SerializeField] public AudioClip deathSound;

    [Header("Health Variables")] [SerializeField]
    private float maxHealth;

    [SerializeField] public float currentHealth;

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
            GameObject.Find("SoundFX").GetComponent<AudioSource>().PlayOneShot(deathSound);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag(("Player")))
        {
            playerHealth = Mathf.RoundToInt(currentHealth);
        }

        if (playerHealth <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            GameObject.Find("SoundFX").GetComponent<AudioSource>().PlayOneShot(deathSound);
            SceneManager.LoadScene(2);
        }

        if (currentHealth <= ((maxHealth / 10) * 8) && currentHealth > ((maxHealth / 10) * 6))
        {
            Debug.Log("HEALTH: 80%");
            Gradient smokeColour = new Gradient();
            var col1 = smoke1.colorOverLifetime;
            var col2 = smoke2.colorOverLifetime;
            col1.enabled = true;
            col2.enabled = true;
            smokeColour.SetKeys(new GradientColorKey[] {new GradientColorKey(new Color32(207, 207, 207, 1), 0.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.37f)});
            col1.color = smokeColour;
            col2.color = smokeColour;
        }
        else if (currentHealth <= ((maxHealth / 10) * 6) && currentHealth > ((maxHealth / 10) * 4))
        {
            Debug.Log("HEALTH: 60%");
            Gradient smokeColour = new Gradient();
            var col1 = smoke1.colorOverLifetime;
            var col2 = smoke2.colorOverLifetime;
            col1.enabled = true;
            col2.enabled = true;
            smokeColour.SetKeys(new GradientColorKey[] {new GradientColorKey(new Color32(166, 166, 166, 1), 0.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.37f)});
            col1.color = smokeColour;
            col2.color = smokeColour;
        }
        else if (currentHealth <= ((maxHealth / 10) * 4) && currentHealth > ((maxHealth / 10) * 2))
        {
            Debug.Log("HEALTH: 40%");
            Gradient smokeColour = new Gradient();
            var col1 = smoke1.colorOverLifetime;
            var col2 = smoke2.colorOverLifetime;
            col1.enabled = true;
            col2.enabled = true;
            smokeColour.SetKeys(new GradientColorKey[] {new GradientColorKey(new Color32(116, 116, 116, 1), 0.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.37f)});
            col1.color = smokeColour;
            col2.color = smokeColour;
        }
        else if (currentHealth <= ((maxHealth / 10) * 2) && currentHealth > ((maxHealth / 10) * 1))
        {
            Debug.Log("HEALTH: 20%");
            Gradient smokeColour = new Gradient();
            var col1 = smoke1.colorOverLifetime;
            var col2 = smoke2.colorOverLifetime;
            col1.enabled = true;
            col2.enabled = true;
            smokeColour.SetKeys(new GradientColorKey[] {new GradientColorKey(new Color32(30, 30, 30, 1), 0.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.37f)});
            col1.color = smokeColour;
            col2.color = smokeColour;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        audioSource.PlayOneShot(hitSound);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneToggle : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject deathScreen;
    
    // Start is called before the first frame update
    void Awake()
    {
        startScreen.SetActive(true);
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.playerHealth <= 0)
        {
            deathScreen.SetActive(true);
            startScreen.SetActive(false);
        }
        
        Debug.Log("Player health: " + Health.playerHealth);
    }
}

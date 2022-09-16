using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSettings : MonoBehaviour
{
    private MenuHolderScript menuHolder;
    
    public static StartSettings Instance;

    public static bool playerLives = true;
    
    private void Awake()
    {
        menuHolder = GameObject.Find("MenuHolder").GetComponent<MenuHolderScript>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menuHolder.ChangeMenu();
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Airforce" && Health.playerHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
            playerLives = false;
            Debug.Log("LOAD DEATH MENU");
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                menuHolder.ChangeMenu();
                Debug.Log("Change menu");
            }
        }
        
        Debug.Log("Player health: " + Health.playerHealth);
    }
}

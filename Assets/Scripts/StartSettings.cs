using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSettings : MonoBehaviour
{
    public static StartSettings Instance;

    public static string currentScene;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void Switch(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void Update()
    {
        if (Health.playerHealth <= 0 && Health.playerSpawned)
        {
            SceneManager.LoadScene("Death");
            Health.playerSpawned = false;
        }
    }
}

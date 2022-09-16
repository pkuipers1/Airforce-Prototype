using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHolderScript : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject deathScreen;

    public void ChangeMenu()
    {
        if (StartSettings.playerLives)
        {
            startScreen.SetActive(true);
            deathScreen.SetActive(false);
        }
        else if (!StartSettings.playerLives)
        {
            deathScreen.SetActive(true);
            startScreen.SetActive(false);
            StartSettings.playerLives = true;
        }
    }
}

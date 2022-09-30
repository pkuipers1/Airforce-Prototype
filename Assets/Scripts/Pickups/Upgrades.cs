using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Upgrades : MonoBehaviour
{
    public GameObject ScoreText;
    public static int Score = 0;
    public int Value;

    public GameObject EngineON;
    public GameObject EngineOFF;
    public GameObject BombON;
    public GameObject BombOFF;

    public static bool engineUpgrade;
    public static bool bombUpgrade;
    public static int points;

    void Start()
    {
        Score = 0;
        EngineON.SetActive(false);
        BombON.SetActive(false);
    }

    void Update()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        points = Score;
    }

    private void OnParticleCollision(GameObject other)
    {
        switch(other.name)
        {
            case "Bullets":
                Value = Mathf.RoundToInt(Random.Range(15, 50));
                Score += Value;
                break;

            case "Engine":
                EngineON.SetActive(true);
                EngineOFF.SetActive(false);
                engineUpgrade = true;
                break;

            case "Bomb":
                BombON.SetActive(true);
                BombOFF.SetActive(false);
                bombUpgrade = true;
                break;
        }
    }
    
    //private void OnParticleTrigger()
    //{
    //    switch(other.name)
    //    {
    //        case "Bullets":
    //            Value = Mathf.RoundToInt(Random.Range(15, 50));
    //            Score += Value;
    //            break;
    //
    //        case "Engine":
    //            EngineON.SetActive(true);
    //            EngineOFF.SetActive(false);
    //            engineUpgrade = true;
    //            break;
    //
    //        case "Bomb":
    //            BombON.SetActive(true);
    //            BombOFF.SetActive(false);
    //            bombUpgrade = true;
    //            break;
    //    }
    //}
}   
    
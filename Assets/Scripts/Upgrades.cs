using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject ScoreText;
    public static int Score = 0;
    public int Value = 1;

    public GameObject EngineON;
    public GameObject BombON;

    void Start()
    {
        Score = 0;
        EngineON.SetActive(false);
        BombON.SetActive(false);
    }

    void Update()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString();
    }

    private void OnParticleCollision(GameObject other)
    {
        switch(other.name)
        {
            case "Bullets":
                Score += Value;
                break;

            case "Engine":
                EngineON.SetActive(true);
                break;

            case "Bomb":
                BombON.SetActive(true);
                break;

        }
    }
}

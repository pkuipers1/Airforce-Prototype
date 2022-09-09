using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text ScoreText;
    public static int Score = 0;
    public int Value = 1;

    public GameObject EngineON;
    public GameObject BombON;

    void Start()
    {
        Score = 0;
        EngineON.SetActive(true);
        BombON.SetActive(true);
    }

    void Update()
    {
        ScoreText.text = "" + Score;
    }

    private void OnParticleCollision(GameObject other)
    {
        switch(other.name)
        {
            case "Bullets":
                Score += Value;
                break;

            case "Engine":
                EngineON.SetActive(false);
                break;

            case "Bomb":
                BombON.SetActive(false);
                break;

        }
    }
}

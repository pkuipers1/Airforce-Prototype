using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneUpgrade : MonoBehaviour
{
    [SerializeField] private Sprite currentSprite;
    [SerializeField] private Sprite upgradeSprite;

    [SerializeField] private bool engineRequired;
    [SerializeField] private bool bombRequired;

    [SerializeField] private int cost;

    private void Start()
    {
        currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        //        if(Upgrades.Score >= cost && Upgrades.bombUpgrade)
    }

    public void UpgradePlane()
    {
        Debug.Log("ButtonPressed");
        if(Upgrades.Score >= cost && Upgrades.bombUpgrade)
        {
            currentSprite = upgradeSprite;
        }
    }
}

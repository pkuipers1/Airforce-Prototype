using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAutoFire : MonoBehaviour
{
    public GameObject AutomaticON;
    public GameObject AutomaticOFF;

    void Start()
    {
        AutomaticON.SetActive(false);
        AutomaticOFF.SetActive(false);
    }

    private void Update()
    {
        CheckAutoFire();
    }

    public void CheckAutoFire()
    {
        if (Shooting.autoFire)
        {
            AutomaticON.SetActive(true);
            AutomaticOFF.SetActive(false);
        }
        else if (!Shooting.autoFire)
        {
            AutomaticON.SetActive(false);
            AutomaticOFF.SetActive(true);
        }
    }
}

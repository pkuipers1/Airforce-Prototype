using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAutoFire : MonoBehaviour
{
    public GameObject AutomaticON;

    void Start()
    {
        AutomaticON.SetActive(true);
    }
    public void AutoFireON()
    {
        if (AutomaticON.activeInHierarchy == true)
        {
            AutomaticON.SetActive(false);
        }
        else if (AutomaticON.activeInHierarchy == false)
        {
            AutomaticON.SetActive(true);
        }
    }
}

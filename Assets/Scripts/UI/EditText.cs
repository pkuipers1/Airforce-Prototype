using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    
    private void Update()
    {
        SetHealthText();
    }

    public void SetHealthText()
    {
        healthText.text = Health.playerHealth.ToString();
    }
}

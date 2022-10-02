using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class InputParser : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlsActions;

    [Header("Scripts")]
    //[SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Shooting shooting;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlsActions = _playerInput.actions;
        
        //_playerControlsActions["Shooting"].performed += shooting;
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = _playerControlsActions["Moving"].ReadValue<Vector2>();
        //Code om de vector te geven aan de playermovement functie
    }
    
    private void Shooting(InputAction.CallbackContext context) => shooting.InitialisShooting();
}

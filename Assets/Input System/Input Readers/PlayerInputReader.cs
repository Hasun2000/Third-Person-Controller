using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    /// <summary>
    /// This class handles all the inputs for the game. including the player inputs and the global inputs.
    /// This uses the new input system package.
    /// </summary>
    
    //public static InputReader Instance { get; private set; } // Singleton instance
    [Header("Input Class")]
    private GameInput _gameInput; // The input action script
    
    [Header("Player Events")]
    public Action<Vector2> Move;
    public Action<Vector2> Look;
    public Action PrimaryActionEvent;
    public Action<bool> SecondaryActionEvent;
    public Action TertiaryActionEvent;
    
    [Header("UI Events")]
    public Action PauseEvent;
    
    private void Awake()
    {
        //Instance = this;
        _gameInput = new GameInput();
    }
    
    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Player.Move.performed += OnMove;    
        _gameInput.Player.Look.performed += OnLook;
        _gameInput.Player.Primary.performed += OnPrimaryAction;
        _gameInput.Player.Secondary.performed += OnSecondaryAction;
        _gameInput.Player.Secondary.canceled += OnSecondaryAction;
        _gameInput.Player.Tertiary.performed += OnTertiaryAction;
    }
    
    private void OnDisable()
    {
        _gameInput.Player.Move.performed -= OnMove;
        _gameInput.Player.Look.performed -= OnLook;
        _gameInput.Player.Primary.performed -= OnPrimaryAction;
        _gameInput.Player.Secondary.performed -= OnSecondaryAction;
        _gameInput.Player.Secondary.canceled -= OnSecondaryAction;
        _gameInput.Player.Tertiary.performed -= OnTertiaryAction;
        _gameInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnLook(InputAction.CallbackContext context)
    {
        Look?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnPrimaryAction(InputAction.CallbackContext context)
    {
        PrimaryActionEvent?.Invoke();
    }
    
    private void OnSecondaryAction(InputAction.CallbackContext context)
    {
        SecondaryActionEvent?.Invoke(context.ReadValueAsButton());
    }
    
    private void OnTertiaryAction(InputAction.CallbackContext context)
    {
        TertiaryActionEvent?.Invoke();
    }
    
    private void OnPause(InputAction.CallbackContext context)
    {
        PauseEvent?.Invoke();
    }
}

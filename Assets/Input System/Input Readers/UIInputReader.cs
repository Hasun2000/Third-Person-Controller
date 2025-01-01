using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputReader : MonoBehaviour
{
    [Header("Input Class")]
    private GameInput _gameInput; // The input action script
    
    [Header("UI Events")]
    public Action<Vector2> NavigateEvent;
    public Action SubmitEvent;
    public Action CancelEvent;
    public Action<Vector2> PointEvent;
    public Action ClickEvent;
    public Action<Vector2> ScrollEvent;
    public Action MiddleClickEvent;
    public Action RightClickEvent;
    
    private void Awake()
    {
        _gameInput = new GameInput();
    }
    
    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.UI.Navigate.performed += OnNavigate;    
        _gameInput.UI.Submit.performed += OnSubmit;
        _gameInput.UI.Cancel.performed += OnCancel;
        _gameInput.UI.Point.performed += OnPoint;
        _gameInput.UI.Click.performed += OnClick;
        _gameInput.UI.ScrollWheel.performed += OnScroll;
        _gameInput.UI.MiddleClick.performed += OnMiddleClick;
        _gameInput.UI.RightClick.performed += OnRightClick;
    }
    
    private void OnDisable()
    {
        _gameInput.UI.Navigate.performed -= OnNavigate;
        _gameInput.UI.Submit.performed -= OnSubmit;
        _gameInput.UI.Cancel.performed -= OnCancel;
        _gameInput.UI.Point.performed -= OnPoint;
        _gameInput.UI.Click.performed -= OnClick;
        _gameInput.UI.ScrollWheel.performed -= OnScroll;
        _gameInput.UI.MiddleClick.performed -= OnMiddleClick;
        _gameInput.UI.RightClick.performed -= OnRightClick;
        _gameInput.Disable();
    }
    
    private void OnNavigate(InputAction.CallbackContext context)
    {
        NavigateEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnSubmit(InputAction.CallbackContext context)
    {
        SubmitEvent?.Invoke();
    }
    
    private void OnCancel(InputAction.CallbackContext context)
    {
        CancelEvent?.Invoke();
    }
    
    private void OnPoint(InputAction.CallbackContext context)
    {
        PointEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnClick(InputAction.CallbackContext context)
    {
        ClickEvent?.Invoke();
    }
    
    private void OnScroll(InputAction.CallbackContext context)
    {
        ScrollEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnMiddleClick(InputAction.CallbackContext context)
    {
        MiddleClickEvent?.Invoke();
    }
    
    private void OnRightClick(InputAction.CallbackContext context)
    {
        RightClickEvent?.Invoke();
    }
}

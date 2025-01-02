using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private static readonly int IsAiming = Animator.StringToHash("IsAiming");

    [Header("Components")]
    private Animator _animator;
    private PlayerInputReader _inputReader;
    
    //
    private bool _isAiming;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _inputReader = GetComponent<PlayerInputReader>();
    }
    
    private void OnEnable()
    {
        _inputReader.SecondaryActionEvent += OnAim;
    }
    
    private void OnDisable()
    {
        _inputReader.SecondaryActionEvent -= OnAim;
    }

    private void OnAim(bool isAiming)
    {
        _isAiming = isAiming;
        _animator.SetBool(IsAiming, _isAiming);
    }
}

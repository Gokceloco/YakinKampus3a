using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerAnimationState _playerAnimationState;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PlayIdleAnimation()
    {
        if (_playerAnimationState != PlayerAnimationState.Idle)
        {
            _animator.ResetTrigger("Run");
            _animator.SetTrigger("Idle");
            _playerAnimationState = PlayerAnimationState.Idle;
        }
    }
    public void PlayRunAnimation(float runDirection)
    {
        _animator.SetFloat("RunDirection", runDirection);
        if (_playerAnimationState != PlayerAnimationState.Run)
        {
            _animator.ResetTrigger("Idle");
            _animator.SetTrigger("Run");
            _playerAnimationState = PlayerAnimationState.Run;
        }
    }
}

public enum PlayerAnimationState
{
    Idle,
    Run,
}
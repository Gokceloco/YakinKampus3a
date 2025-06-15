using System;
using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    public float speed;

    [Space(10)]
    [Header("Jump")]    
    public bool isJumpControlActive;
    public float jumpPower;
    public LayerMask groundLayerMask;

    [Space(10)]
    [Header("Look At Mouse")]
    public bool playerLooksAtMouse;

    private Rigidbody _rb;
    private bool _isGrounded;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        MovePlayer();
        if (playerLooksAtMouse)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 50, groundLayerMask))
        {
            var lookPos = hit.point;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
        }
    }

    void MovePlayer()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }

        if (direction.magnitude > 0)
        {
            var angle = Vector3.SignedAngle(transform.forward, direction.normalized, Vector3.up);
            _playerAnimator.PlayRunAnimation(angle);
        }
        else
        {
            _playerAnimator.PlayIdleAnimation();
        }

        var yVel = _rb.linearVelocity;

        yVel.x = 0;
        yVel.z = 0;

        _rb.linearVelocity = direction.normalized * speed + yVel;

        if (isJumpControlActive)
        {
            _isGrounded = Physics.Raycast(transform.position + Vector3.up *  .1f, Vector3.down, .5f, groundLayerMask);
        }

        if (isJumpControlActive && _isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpPower, _rb.linearVelocity.z);
        }
    }

    internal void RestartPlayerNavigator()
    {
        _rb.position = Vector3.zero;
    }
}

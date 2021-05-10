using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _playerRotationSpeed;
    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _grounded;
    private float _speedWalk = 1.0f;
    private float _speedRun = 2.0f;
    private float _gravity = Physics.gravity.y;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _speedWalk = Input.GetKey(KeyCode.LeftShift) ? _speedRun : _speedWalk;
        _grounded = _controller.isGrounded;
        if (_velocity.y <= 0.02)
        {
            _velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(x, 0.0f, z);

        if (z != 0)
        {
            _controller.Move(transform.forward * z * _speedWalk * Time.deltaTime);
            if (z < 0)
            {
                _animator.ResetTrigger("Walk");
                _animator.ResetTrigger("Run");
                _animator.SetTrigger("WalkBackward");
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _animator.SetTrigger("Run");
                    _animator.ResetTrigger("Walk");
                    _animator.ResetTrigger("WalkBackward");
                }
                else
                {
                    _animator.SetTrigger("Walk");
                    _animator.ResetTrigger("Run");
                    _animator.ResetTrigger("WalkBackward");
                }
            }
        }
        else
        {
            _animator.ResetTrigger("Run");
            _animator.ResetTrigger("WalkBackward");
            _animator.ResetTrigger("Walk");
        }
        if (x != 0)
        {
            transform.Rotate(transform.up * x * _playerRotationSpeed * Time.deltaTime);
        }
    }
}
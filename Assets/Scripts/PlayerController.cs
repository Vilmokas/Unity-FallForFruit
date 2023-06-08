using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    AnimationManager _animationManager;
    Rigidbody _body;
    float _direction;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _animationManager = GetComponent<AnimationManager>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            Move();
        }
    }

    void Move()
    {
        _body.AddForce(Vector3.right * _direction * _speed);
        _animationManager.PlayWalkAnimation(_direction, _body.velocity.magnitude);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
        SoundManager.Instance.PlayWalkSound();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] ParticleSystem _walkParticle;
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
        if (!GameManager.Instance.IsGameOver && !GameManager.Instance.IsGamePaused)
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(Vector3.right * _direction * _speed * Time.deltaTime);
        _animationManager.PlayWalkAnimation(_direction, _body.velocity.magnitude);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
        if (!GameManager.Instance.IsGameOver && !GameManager.Instance.IsGamePaused)
        {
            SoundManager.Instance.PlayWalkSound();
            _walkParticle.Play();
            if (_direction == 0 && _walkParticle.isPlaying)
            {
                _walkParticle.Stop();
            }
        }
    }
}

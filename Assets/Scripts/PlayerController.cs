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
    int _speedModifier;

    private void Start()
    {
        _speedModifier = 0;
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
        var speed = _speed - (_speedModifier / 10f);
        Debug.Log("speed with modifier: " + speed);
        transform.Translate(Vector3.right * _direction * speed * Time.deltaTime);
        _animationManager.PlayWalkAnimation(_direction, _body.velocity.magnitude);
    }

    public void ChangeSpeedModifier(int modifier)
    {
        _speedModifier = modifier;
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

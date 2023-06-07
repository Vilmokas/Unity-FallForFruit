using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody _body;
    float _direction;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        _body.AddForce(Vector3.right * _direction * _speed);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }
}

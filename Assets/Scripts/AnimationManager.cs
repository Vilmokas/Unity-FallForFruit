using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void PlayWalkAnimation(float speed, float velocity)
    {
        _animator.SetFloat("speed", speed);
        _animator.SetFloat("velocity", velocity);
    }
}

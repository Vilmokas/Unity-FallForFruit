using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    [SerializeField] AudioClip _catchSound;
    [SerializeField] AudioClip _objectSpawnSound;
    [SerializeField] AudioClip _objectHitGroundSound;
    [SerializeField] AudioClip _objectDepositSound;
    [SerializeField] AudioClip _walkSound;
    AudioSource _audioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCatchSound()
    {
        _audioSource.PlayOneShot(_catchSound, 0.5f);
    }

    public void PlayObjectSpawnSound()
    {
        _audioSource.PlayOneShot(_objectSpawnSound, 0.4f);
    }

    public void PlayObjectHitGroundSound()
    {
        _audioSource.PlayOneShot(_objectHitGroundSound, 0.5f);
    }

    public void PlayObjectDepositSound()
    {
        _audioSource.PlayOneShot(_objectDepositSound, 0.4f);
    }

    public void PlayWalkSound()
    {
        _audioSource.PlayOneShot(_walkSound, 0.7f);
    }
}

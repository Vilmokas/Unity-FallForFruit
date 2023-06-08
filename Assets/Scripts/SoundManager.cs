using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

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

    [SerializeField] AudioClip _catchSound;
    [SerializeField] AudioClip _objectSpawnSound;
    AudioSource _audioSource;

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
}

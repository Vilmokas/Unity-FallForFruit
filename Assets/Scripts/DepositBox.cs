using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositBox : MonoBehaviour
{
    [SerializeField] ParticleSystem _depositParticle;

    public void PlayDepositParticle()
    {
        _depositParticle.Play();
    }
}

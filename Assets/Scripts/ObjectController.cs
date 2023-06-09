using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject _destroyParticle;
    [SerializeField] GameObject _trailParticle;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Health>().ReduceHealth(1);
            SoundManager.Instance.PlayObjectHitGroundSound();
            Instantiate(_destroyParticle, transform.position, _destroyParticle.transform.rotation);
        }
    }

    public void StopTrailParticle()
    {
        _trailParticle.SetActive(false);
    }
}

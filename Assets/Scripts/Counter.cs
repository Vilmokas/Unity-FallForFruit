using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentCountText;
    [SerializeField] TextMeshProUGUI _storedCountText;
    [SerializeField] List<GameObject> _caughtObjects;
    [SerializeField] GameObject _caughtObjectsParent;
    [SerializeField] ParticleSystem _catchParticle;
    int _currentCount;
    int _storedCount;

    private void Start()
    {
        _currentCount = 0;
        _storedCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            CatchObject(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Deposit"))
        {
            DepositObjects();
        }
    }

    void CatchObject(GameObject caughtObject)
    {
        _currentCount += 1;
        _currentCountText.text = _currentCount.ToString();
        _caughtObjects.Add(caughtObject);
        caughtObject.transform.SetParent(_caughtObjectsParent.transform, true);
        SoundManager.Instance.PlayCatchSound();
        _catchParticle.Play();
    }

    void DepositObjects()
    {
        if (_currentCount > 0)
        {
            _storedCount += _currentCount;
            _storedCountText.text = _storedCount.ToString();
            _currentCount = 0;
            _currentCountText.text = _currentCount.ToString();

            foreach (GameObject caughtObject in _caughtObjects)
            {
                Destroy(caughtObject);
            }

            _caughtObjects.Clear();
            SoundManager.Instance.PlayObjectDepositSound();
        }
    }
}

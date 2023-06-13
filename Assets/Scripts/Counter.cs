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
    PlayerController _playerController;
    int _currentCount;
    int _storedCount;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _currentCount = 0;
        _storedCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            CatchObject(other.gameObject);
            other.GetComponent<ObjectController>().StopTrailParticle();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Deposit"))
        {
            DepositObjects(other.GetComponent<DepositBox>());
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
        _playerController.ChangeSpeedModifier(_currentCount);
        UIManager.Instance.ChangeEndGameScores(_storedCount, _currentCount);
    }

    void DepositObjects(DepositBox depositBox)
    {
        if (_currentCount > 0)
        {
            _storedCount += _currentCount;
            _storedCountText.text = _storedCount.ToString();
            _currentCount = 0;
            _currentCountText.text = _currentCount.ToString();
            _playerController.ChangeSpeedModifier(_currentCount);

            foreach (GameObject caughtObject in _caughtObjects)
            {
                Destroy(caughtObject);
            }

            _caughtObjects.Clear();
            SoundManager.Instance.PlayObjectDepositSound();
            depositBox.PlayDepositParticle();
            UIManager.Instance.ChangeEndGameScores(_storedCount, _currentCount);
        }
    }
}

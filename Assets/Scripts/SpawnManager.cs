using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _objectPrefabs;
    [SerializeField] float _spawnDelay;
    public float SpawnDelay { get { return _spawnDelay; } }
    [SerializeField] List<Transform> _spawnPositions;
    [SerializeField] List<ParticleSystem> _spawnParticles;
    float _waitTime;

    private void Start()
    {
        _waitTime = 3f;
        StartCoroutine(RoundCounter());
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_waitTime);
        while (!GameManager.Instance.IsGameOver)
        {
            var randomObjectIndex = Random.Range(0, _objectPrefabs.Count);
            var randomPositionIndex = Random.Range(0, _spawnPositions.Count);
            var fallObject = Instantiate(_objectPrefabs[randomObjectIndex], _spawnPositions[randomPositionIndex].position, _objectPrefabs[randomObjectIndex].transform.rotation);
            SoundManager.Instance.PlayObjectSpawnSound();
            UIManager.Instance.ShowObjectIndicator(fallObject);
            _spawnParticles[randomPositionIndex].Play();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    IEnumerator RoundCounter()
    {
        for (var i = _waitTime; i > 0; i--)
        {
            UIManager.Instance.ChangeCountdownText(i.ToString());
            yield return new WaitForSeconds(1f);
        }
        UIManager.Instance.ChangeCountdownText("Start!");
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.ChangeCountdownText("hide");
    }
}

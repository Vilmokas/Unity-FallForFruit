using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _objectPrefabs;
    [SerializeField] float _spawnDelay;
    [SerializeField] List<Transform> _spawnPositions;
    [SerializeField] List<ParticleSystem> _spawnParticles;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            yield return new WaitForSeconds(_spawnDelay);
            var randomObjectIndex = Random.Range(0, _objectPrefabs.Count);
            var randomPositionIndex = Random.Range(0, _spawnPositions.Count);
            var fallObject = Instantiate(_objectPrefabs[randomObjectIndex], _spawnPositions[randomPositionIndex].position, _objectPrefabs[randomObjectIndex].transform.rotation);
            SoundManager.Instance.PlayObjectSpawnSound();
            UIManager.Instance.ShowObjectIndicator(fallObject);
            _spawnParticles[randomPositionIndex].Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _objectPrefabs;
    [SerializeField] float _spawnDelay;
    [SerializeField] List<Transform> _spawnPositions;
    bool _isGameActive;

    private void Start()
    {
        _isGameActive = true;
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnDelay);
            var randomObjectIndex = Random.Range(0, _objectPrefabs.Count);
            var randomPositionIndex = Random.Range(0, _spawnPositions.Count);
            Instantiate(_objectPrefabs[randomObjectIndex], _spawnPositions[randomPositionIndex].position, _objectPrefabs[randomObjectIndex].transform.rotation);
        }
    }
}
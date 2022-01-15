using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;

    private List<SpawnPoint> _spawnPoints;
    private WaitForSeconds _delayEnemySpawn = new WaitForSeconds(2f);
    private bool _isPlaying = true;

    private void Start()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
        StartCoroutine(SpawnsEnemy());
    }

    private IEnumerator SpawnsEnemy()
    {
        while (_isPlaying)
        {
            foreach (SpawnPoint point in _spawnPoints)
            {
                EnemyMover newEnemy = Instantiate(_enemyPrefab, point.transform.position, Quaternion.identity, point.transform);
                newEnemy.SetEndPoint(point.EndPosition);
                yield return _delayEnemySpawn;
            }
        }
    }
}

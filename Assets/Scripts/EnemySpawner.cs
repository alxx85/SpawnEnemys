using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _prefab;

    private List<SpawnPoint> _spawnPoints;
    private WaitForSeconds _delay = new WaitForSeconds(2f);
    private bool _isPlaying = true;

    private void Start()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isPlaying)
        {
            foreach (SpawnPoint point in _spawnPoints)
            {
                EnemyMover newEnemy = Instantiate(_prefab, point.transform.position, Quaternion.identity, point.transform);
                newEnemy.SetEndPoint(point.EndPosition);
                newEnemy.StartEnemyMove();
                yield return _delay;
            }
        }
    }
}

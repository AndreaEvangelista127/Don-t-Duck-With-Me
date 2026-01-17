using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _minimumSpawnTime;

    [SerializeField] private float _maximumSpawnTime;

    private float _timeUntilSpawns;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        _timeUntilSpawns -= Time.deltaTime; //when this timer reaches 0, spawn an enemy prefab

        if(_timeUntilSpawns <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            //Now we reset the timer the next enemy prefab spawn
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawns = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}

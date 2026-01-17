using Unity.VisualScripting;
using UnityEngine;

public class SpawnRandomItems : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemPrefabs;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float _liveDuration;

    [Header("Spawn Area")]
    [SerializeField] private Collider2D _boxConfines; // Assign a BoxCollider2D (or any Collider2D with bounds) in the Inspector
    [SerializeField] private bool _isGizmosOn;

    private GameObject _spawnItem;
    private float _timeUntilSpawns;
    private int _numberOfPrefab;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        if (_itemPrefabs == null || _itemPrefabs.Length == 0)
            return;

        _spawnItem = SetItemPrefab(_itemPrefabs);

        _timeUntilSpawns -= Time.deltaTime;

        if (_timeUntilSpawns <= 0f)
        {
            Vector2 spawnPos = transform.position;

            if (_boxConfines != null)
            {
                Bounds b = _boxConfines.bounds;
                float randomX = Random.Range(b.min.x, b.max.x);
                float randomY = Random.Range(b.min.y, b.max.y);
                spawnPos = new Vector2(randomX, randomY);
            }

            GameObject spawned = Instantiate(_spawnItem, spawnPos, Quaternion.identity);

            if (_liveDuration > 0f)
            {
                Destroy(spawned, _liveDuration);
            }

            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawns = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private GameObject SetItemPrefab(GameObject[] items)
    {
        _numberOfPrefab = Random.Range(0, items.Length);
        return items[_numberOfPrefab];
    }

    // Optional: Visualisierung im Editor (Gizmo) für die Spawn-Area
    private void OnDrawGizmosSelected()
    {
        if(_isGizmosOn)
        {
            if (_boxConfines == null) return;
            Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
            Gizmos.DrawCube(_boxConfines.bounds.center, _boxConfines.bounds.size);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_boxConfines.bounds.center, _boxConfines.bounds.size);
        }
    }
}
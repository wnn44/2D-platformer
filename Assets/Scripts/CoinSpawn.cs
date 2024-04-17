using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private List<PointSpawn> _spawnPoints = new List<PointSpawn>();
    [SerializeField] private Coin _prefabCoin;
    [SerializeField] private CollisionDetector _collisionDetector;

    private int _oldNumberSpawner = 0;
    private int _numberSpawner = 0;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _collisionDetector.OnCollisionDetectedCoin += ActionCoin;
    }

    private void OnDisable()
    {
        _collisionDetector.OnCollisionDetectedCoin -= ActionCoin;
    }

    private void ActionCoin(Coin coin)
    {
        DestroyCoin(coin);

        Spawn();
    }

    private void Spawn()
    {
        while (_oldNumberSpawner == _numberSpawner)
        {
            _numberSpawner = Random.Range(0, _spawnPoints.Count);
        }

        _oldNumberSpawner = _numberSpawner;

        PointSpawn spawnPoint = _spawnPoints[_numberSpawner];

        Vector3 positionSpawnPoint = spawnPoint.transform.position;

        Instantiate(_prefabCoin, positionSpawnPoint, Quaternion.identity);
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
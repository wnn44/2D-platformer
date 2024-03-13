using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private List<PointSpawn> _spawnPoints = new List<PointSpawn>();
    [SerializeField] private Coin _prefabCoin;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        CollisionDetector.OnCollisionDetectedCoin += ActionCoin;
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDetectedCoin -= ActionCoin;
    }

    private void ActionCoin(Coin coin)
    {
        DestroyCoin(coin);

        Spawn();
    }

    private void Spawn()
    {
        int numberSpawner = Random.Range(0, _spawnPoints.Count);

        PointSpawn spawnPoint = _spawnPoints[numberSpawner];

        Vector3 positionSpawnPoint = spawnPoint.transform.position;

        Instantiate(_prefabCoin, positionSpawnPoint, Quaternion.identity);
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
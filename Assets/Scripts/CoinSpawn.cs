using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private CoinType _prefabCoin;

    private void OnEnable()
    {
        Coin.CoinFound += Spawn;
    }

    private void OnDisble()
    {
        Coin.CoinFound -= Spawn;
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int numberSpawner = UnityEngine.Random.Range(0, _spawnPoints.Count);

        GameObject spawnPoint = _spawnPoints[numberSpawner];
        Vector3 positionSpawnPoint = spawnPoint.gameObject.transform.position;

        Instantiate(_prefabCoin, positionSpawnPoint, Quaternion.identity);
    }
}
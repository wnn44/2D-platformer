using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private Coin _prefabCoin;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int numberSpawner = Random.Range(0, _spawnPoints.Count);
        Debug.Log(numberSpawner);
        GameObject spawnPoint = _spawnPoints[numberSpawner];
        Vector3 positionSpawnPoint = spawnPoint.gameObject.transform.position;

        Instantiate(_prefabCoin, positionSpawnPoint, Quaternion.identity);
    }
}
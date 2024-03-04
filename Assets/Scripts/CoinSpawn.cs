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

    private void OnEnable()
    {
        CollisionDetector.OnCollisionDetectedCoin += Spawn;
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDetectedCoin -= Spawn;
    }

    private void Spawn()
    {
        int numberSpawner = Random.Range(0, _spawnPoints.Count);

        Debug.Log(_spawnPoints.GetType());

        GameObject spawnPoint = _spawnPoints[numberSpawner];
        Vector3 positionSpawnPoint = spawnPoint.gameObject.transform.position;

        Instantiate(_prefabCoin, positionSpawnPoint, Quaternion.identity);
    }
}
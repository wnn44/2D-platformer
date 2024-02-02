using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject _prefabCoin;

    private void OnEnable()
    {
        Coin.FoundCoin += Spawn;
    }

    private void OnDisble()
    {
        Coin.FoundCoin -= Spawn;
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
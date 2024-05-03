using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitHealthSpawn : MonoBehaviour
{
    [SerializeField] private List<PointSpawn> _spawnKitHealth = new List<PointSpawn>();
    [SerializeField] private KitHealth _prefabKitHealth;
    [SerializeField] private CollisionDetector _collisionDetector;

    private int maxTimeSpawn = 20;
    private int minTimeSpawn = 10;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _collisionDetector.OnCollisionDetectedKitHealth += ActionKitHealth;
    }

    private void OnDisable()
    {
        _collisionDetector.OnCollisionDetectedKitHealth -= ActionKitHealth;
    }

    public void ActionKitHealth(KitHealth kitHealth)
    {
        DestroyKitHealth(kitHealth);

        Spawn();
    }

    public void DestroyKitHealth(KitHealth kitHealth)
    {
        Destroy(kitHealth.gameObject);
    }

    public void Spawn()
    {
        StartCoroutine(CreateMedicines());
    }

    private IEnumerator CreateMedicines()
    {
        int numberSpawner = Random.Range(0, _spawnKitHealth.Count);
        int timeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);

        yield return new WaitForSeconds(timeSpawn);

        PointSpawn spawnPoint = _spawnKitHealth[numberSpawner];

        Vector2 positionSpawnPoint = spawnPoint.transform.position;

        Instantiate(_prefabKitHealth, positionSpawnPoint, Quaternion.identity);
    }
}

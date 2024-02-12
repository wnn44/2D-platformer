using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitHealthSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnKitHealth = new List<GameObject>();
    [SerializeField] private KitHealthType _prefabKitHealth;

    private int maxTimeSpawn = 20;
    private int minTimeSpawn = 10;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        KitHealth.KitHealthAdd += Spawn;
    }

    private void OnDisble()
    {
        KitHealth.KitHealthAdd -= Spawn;
    }

    public void Spawn()
    {
        StartCoroutine(CreateMedicines());
    }

    IEnumerator CreateMedicines()
    {
        int numberSpawner = UnityEngine.Random.Range(0, _spawnKitHealth.Count);
        int timeSpawn = UnityEngine.Random.Range(minTimeSpawn, maxTimeSpawn);        
        
        yield return new WaitForSeconds(timeSpawn);

        GameObject spawnPoint = _spawnKitHealth[numberSpawner];
        Vector2 positionSpawnPoint = spawnPoint.gameObject.transform.position;

        Instantiate(_prefabKitHealth, positionSpawnPoint, Quaternion.identity);
    }
}

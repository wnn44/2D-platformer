using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KitHealthSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnKitHealth = new List<GameObject>();
    [SerializeField] private KitHealthType _prefabKitHealth;

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

        StartCoroutine(Spawn1());


    }

    IEnumerator Spawn1()
    {
        yield return new WaitForSeconds(10f);

        int numberSpawner = UnityEngine.Random.Range(0, _spawnKitHealth.Count);

        GameObject spawnPoint = _spawnKitHealth[numberSpawner];
        Vector2 positionSpawnPoint = spawnPoint.gameObject.transform.position;

        Instantiate(_prefabKitHealth, positionSpawnPoint, Quaternion.identity);
    }
}

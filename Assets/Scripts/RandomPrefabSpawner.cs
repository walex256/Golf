using UnityEngine;
using System.Collections.Generic;

public class RandomPrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform parentTransform;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void SpawnRandom()
    {
        if (prefabs == null || prefabs.Length == 0 || spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Prefabs или spawnPoints не назначены!");
            return;
        }

        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];        
        GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        
        if (parentTransform != null)
            obj.transform.SetParent(parentTransform, worldPositionStays: true);

        spawnedObjects.Add(obj);

        Debug.Log($"Spawned {obj.name} at {spawnPoint.position}");
    }

    public void DestroyAll()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }
        spawnedObjects.Clear();
        Debug.Log("Все объекты уничтожены.");
    }
}

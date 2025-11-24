using UnityEngine;
using System.Collections.Generic;

public class RandomPrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] spawnPointsGround;
    [SerializeField] private Transform[] spawnPointsFly;
    [SerializeField] private Transform parentTransform;

    private readonly List<GameObject> spawnedObjects = new();

    public void SpawnRandom()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogWarning("Prefabs не назначены!");
            return;
        }

        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        // ----- ЛЕТАЮЩИЙ -----
        if (prefab.layer == 10)
        {            
            Transform point = spawnPointsFly[Random.Range(0, spawnPointsFly.Length)];

            GameObject obj = Instantiate(prefab, point.position, prefab.transform.rotation, parentTransform);
            spawnedObjects.Add(obj);

            Debug.Log($"FLY Spawned {obj.name} at {point.position}");
        }
        // ----- НАЗЕМНЫЙ -----
        else
        {            
            Transform point = spawnPointsGround[Random.Range(0, spawnPointsGround.Length)];

            GameObject obj = Instantiate(prefab, point.position, prefab.transform.rotation, parentTransform);
            spawnedObjects.Add(obj);

            Debug.Log($"GROUND Spawned {obj.name} at {point.position}");
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }

        spawnedObjects.Clear();
        Debug.Log("Все объекты уничтожены");
    }
}

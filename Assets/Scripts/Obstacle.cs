using System;
using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private RandomPrefabSpawner m_spawner;
    private void Start()
    {
        m_spawner = FindFirstObjectByType<RandomPrefabSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 4)
        {
            Debug.Log("Z");
            StartCoroutine(DestroyObject());
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        m_spawner.DestroyAll();        
        m_spawner.SpawnRandom();
    }
}

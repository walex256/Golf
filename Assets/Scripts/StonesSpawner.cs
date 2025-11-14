using UnityEngine;
namespace Golf
{
    public class StonesSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefab;

        [SerializeField] private Transform m_spawnPoint;

        public Stone Spawn()
        {
            var prefabs = m_prefab[Random.Range(0, m_prefab.Length)];
            return Instantiate(prefabs, m_spawnPoint.position, m_spawnPoint.rotation);
        }



    }
}


using UnityEngine;
namespace Golf
{
    public class StonesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_prefab;

        [SerializeField] private Transform m_spawnPoint;

        public void Spawn()
        {
            var prefabs = m_prefab[Random.Range(0, m_prefab.Length)];
            Instantiate(prefabs, m_spawnPoint.position, m_spawnPoint.rotation);
        }



    }
}


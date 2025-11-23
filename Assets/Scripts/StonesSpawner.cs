using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class StonesSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefab;

        [SerializeField] private Transform m_spawnPoint;

        private List<Stone> m_stones;

        private void Start()
        {
            m_stones = new List<Stone>();
        }
        public Stone Spawn()
        {
            var prefabs = m_prefab[Random.Range(0, m_prefab.Length)];            
            var currentStone = Instantiate(prefabs, m_spawnPoint.position, m_spawnPoint.rotation);
            m_stones.Add(currentStone);
            return currentStone;

        }

        public void StoneDestroy()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }
            m_stones.Clear();
        }

    }
}


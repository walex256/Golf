using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class StonesSpawner : MonoBehaviour
    {
        [SerializeField] private HitObject[] m_prefab;
        [SerializeField] private Transform m_spawnPoint;
        [SerializeField] private float m_spawnRangeY;

        private List<HitObject> m_stones;

        private void Start()
        {
            m_stones = new List<HitObject>();
        }

        public HitObject Spawn()
        {            
            float randomY = Random.Range(-m_spawnRangeY, m_spawnRangeY);
            
            Vector3 spawnPosition = new Vector3(
                m_spawnPoint.position.x,
                m_spawnPoint.position.y + randomY,
                m_spawnPoint.position.z
            );

            var prefabs = m_prefab[Random.Range(0, m_prefab.Length)];
            var currentStone = Instantiate(prefabs, spawnPosition, m_spawnPoint.rotation);
            m_stones.Add(currentStone);
            return currentStone;
        }

        public void StoneDestroy()
        {
            foreach (var stone in m_stones)
            {
                if (stone != null)
                {
                    Destroy(stone.gameObject);
                }
            }
            m_stones.Clear();
        }

    }
}
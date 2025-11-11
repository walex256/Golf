using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] 
        [Min (0.1f)] private float m_spawnRate =0.5f;
        [SerializeField] StonesSpawner m_stonesSpawner;
        [Min(0.1f)] private float m_time;

        private void Start()
        {
            m_time = m_spawnRate;
        }
        void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                m_stonesSpawner.Spawn();
                m_time = 0;
            }

            
        }
    }
}


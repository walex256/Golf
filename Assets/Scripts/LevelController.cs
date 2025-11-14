using System;
using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_missedCount;

        [SerializeField] [Min (0.1f)] private float m_spawnRate =0.5f;

        [SerializeField] StonesSpawner m_stonesSpawner;

        [Min(0.1f)] private float m_time;

        private int m_currentMissedCount;
        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
        }
        private void Start()
        {
            m_time = m_spawnRate;
        }
        void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                Stone stone = m_stonesSpawner.Spawn();

                stone.Hit += OnHit;

                stone.Missed += OnMissed;
                m_time = 0;
            }

            
        }

        private void OnHit(Stone stone)
        {
           stone.Hit -= OnHit;
           stone.Missed -= OnMissed;
           Debug.Log("Hit");

        }

        private void OnMissed(Stone stone)
        {
            stone.Hit -= OnHit;
            stone.Missed -= OnMissed;
            m_missedCount--;
            if (m_missedCount < 0)
            {
                Debug.Log("Game over");
            }
        }

        
    }
}


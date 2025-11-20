using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [Header("Game logic")]
        [SerializeField] private int m_missedCount;
        [SerializeField, Min(0.1f)] private float m_spawnRate = 1f;
        [SerializeField] private StonesSpawner m_stoneSpawner;        
        [SerializeField] private ScoreManager m_scoreManager;

        private int m_currentMissedCount;

        public int Score { get; private set; } = 0;

        private float m_time;

        private List<Stone> m_stones;

        private void Awake()
        {           
            m_stones = new List<Stone>();
        }

        public void Initialize()
        {
            m_currentMissedCount = m_missedCount;
        }

        private void Update()
        {
            UpdateSpawnTimer();
        }

        private void UpdateSpawnTimer()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                SpawnStoneWithEvents();

                m_time = 0;
            }
        }

        private void SpawnStoneWithEvents()
        {
            Stone stone = m_stoneSpawner.Spawn();

            stone.Hit += OnHitStone;
            stone.Missed += OnMissedStone;
        }

        private void OnMissedStone(Stone stone)
        {
            UnsubscribeStone(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over!");
                Finished?.Invoke();

                foreach (Stone item in m_stones)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            m_scoreManager.Increase();
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;
        }

    }
}


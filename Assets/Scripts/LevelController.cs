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
        [SerializeField] private float m_minSpawnTime = 1f;
        [SerializeField] private float m_maxSpawnTime = 3f;
        [SerializeField] private StonesSpawner m_stoneSpawner;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private SaundManager m_saundManager;

        private int m_currentMissedCount;
        private float m_time;
        private float m_nextSpawnTime;
        private List<HitObject> m_stones;

        public int Score { get; private set; } = 0;

        private void Awake()
        {
            m_stones = new List<HitObject>();
        }

        public void Initialize()
        {
            m_currentMissedCount = m_missedCount;
            SetNextSpawnTime(); // Устанавливаем первое случайное время
        }

        private void Update()
        {
            UpdateSpawnTimer();
        }

        private void UpdateSpawnTimer()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_nextSpawnTime)
            {
                SpawnStoneWithEvents();
                m_time = 0;
                SetNextSpawnTime(); // Устанавливаем новое случайное время
            }
        }

        private void SetNextSpawnTime()
        {
            m_nextSpawnTime = UnityEngine.Random.Range(m_minSpawnTime, m_maxSpawnTime);
        }

        private void SpawnStoneWithEvents()
        {
            HitObject stone = m_stoneSpawner.Spawn();

            stone.Hit += OnHitStone;
            stone.Missed += OnMissedStone;
        }

        private void OnMissedStone(HitObject stone)
        {
            UnsubscribeStone(stone);
            m_saundManager.SoundPlay(Sound.stoneFall);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over!");
                Finished?.Invoke();

                foreach (HitObject item in m_stones)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        private void OnHitStone(HitObject stone)
        {
            UnsubscribeStone(stone);
            m_scoreManager.Increase(stone.score);
        }

        private void UnsubscribeStone(HitObject stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissedStone;
        }
    }
}
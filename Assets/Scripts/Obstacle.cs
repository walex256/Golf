using System;
using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Animator m_animator;    
    private ScoreManager m_scoreManager;
    private RandomPrefabSpawner m_spawner;
    private bool isHit;

    private void OnEnable()
    {
        isHit = true;
    }
    private void Start()
    {
        m_animator = FindFirstObjectByType<Animator>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
        m_spawner = FindFirstObjectByType<RandomPrefabSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 4 && isHit)
        {
            if (m_animator != null)
            {
                m_animator.Play("Portal");
            }            
            isHit=false;
            Debug.Log("Z");
            m_scoreManager.Increase(10);
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

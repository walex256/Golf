using Golf;
using System;
using TMPro;
using UnityEngine;

public class GamplayState : MonoBehaviour
{
    [SerializeField] private _PlayerController m_playerController;

    [SerializeField] private LevelController m_levelController;

    [SerializeField] private ScoreManager m_scoreManager;

    [SerializeField] private TextMeshProUGUI m_scoreText;

    private GameStateMachine m_gameStateMachine;
    public void Initialize(GameStateMachine gameStateMachine)
    {
       m_gameStateMachine = gameStateMachine;
    }
    public void Enter()
    {
        m_scoreManager.Reset();
        m_scoreManager.ScoreChanged += OnScoreChanged();


        m_playerController.enabled = true;
        m_levelController.enabled = true;
    }

    private void OnScoreChanged(int score)
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        m_playerController.enabled = false;
        m_levelController.enabled = false;
    }
}

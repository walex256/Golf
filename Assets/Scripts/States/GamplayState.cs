using Golf;
using System;
using TMPro;
using UnityEngine;

public class GamplayState : MonoBehaviour
{
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private TMP_Text m_scoreText;

    private GameStateMachine m_gameStateMachine;

    public void Init(GameStateMachine gameStateMachine)
    {
        m_scoreText.gameObject.SetActive(false);
        m_gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        m_scoreManager.Reset();
        m_scoreManager.ScoreChanged += OnScoreChanged;

        OnScoreChanged(m_scoreManager.score);
        m_scoreText.gameObject.SetActive(true);
        

        m_levelController.enabled = true;
        m_playerController.enabled = true;

        m_levelController.Initialize();

       m_levelController.Finished += OnFinished;
    }
    

    private void OnFinished()
    {       
        m_gameStateMachine.Enter<GameOverState>();
    }
         


    public void Exit()
    {
        m_levelController.enabled = false;
        m_playerController.enabled = false;
        m_scoreText.gameObject.SetActive(false);

        m_levelController.Finished -= OnFinished;
    }

    private void OnScoreChanged(int score)
    {
        Debug.Log(score);
        m_scoreText.text = score.ToString();
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuState : MonoBehaviour
{
    [SerializeField] private Button m_playButton;

    [SerializeField] private GameObject m_mainMenuRoot;

    private GameStateMachine m_GameStateMachine;

    public void Initialize(GameStateMachine gameStateMachine)
    {
        m_mainMenuRoot.SetActive(false);
        m_GameStateMachine = gameStateMachine;
    }
    public void Enter()
    {
        m_mainMenuRoot.SetActive(true);
        m_playButton.onClick.AddListener(OnClikced());
    }
    
    public void Exit()
    {
        m_mainMenuRoot.SetActive(false);
        m_playButton.onClick.RemoveListener(OnClikced);
    }
    private void OnClikced()
    {
       // m_GameStateMachine
    }
}

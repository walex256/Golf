using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuState : StateBase
{
    [SerializeField] private GameObject m_mainMenuRoot;
    [SerializeField] private Button m_playButton;
    [SerializeField] private SaundManager m_soundManager;

    private GameStateMachine m_gameStateMachine;

    public override void Init(GameStateMachine gameStateMachine)
    {
        m_mainMenuRoot.SetActive(false);
        m_gameStateMachine = gameStateMachine;
    }

    public override void Enter()
    {
        m_soundManager.SoundPlay(Sound.gamePlay);
        m_mainMenuRoot.SetActive(true);
        m_playButton.onClick.AddListener(OnClicked);
    }

    public override void Exit()
    {
        m_mainMenuRoot.SetActive(false);
        m_playButton.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        m_soundManager.SoundPlay(Sound.buttonClick);
        m_gameStateMachine.Enter<GamplayState>();
    }
}

using Golf;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : StateBase
{
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private Button m_backMainMenu;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private SaundManager m_soundManager;
    [SerializeField] private StonesSpawner m_spawner;

    private GameStateMachine m_gameStateMachine;


    public override void Init(GameStateMachine gameStateMachine)
    {
        m_gameStateMachine = gameStateMachine;

        m_gameOverPanel.SetActive(false);
    }

    public override void Enter()
    {
        m_soundManager.SoundStop(Sound.gamePlay);
        m_soundManager.SoundPlay(Sound.gameOver);
        m_scoreManager.UpdateRecord();
        m_scoreText.text = m_scoreManager.score.ToString();
        m_backMainMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.SetActive(true);        
        m_spawner.StoneDestroy();
    }

    private void OnClicked()
    {
        m_soundManager.SoundPlay(Sound.buttonClick);
        m_gameStateMachine.Enter<MainMenuState>();
    }

    public override void Exit()
    {
        m_gameOverPanel.SetActive(false);
    }
}

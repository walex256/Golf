using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : StateBase
{
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private Button m_backMainMenu;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    private GameStateMachine m_gameStateMachine;


    public override void Init(GameStateMachine gameStateMachine)
    {
        m_gameStateMachine = gameStateMachine;

        m_gameOverPanel.SetActive(false);
    }

    public override void Enter()
    {
        m_scoreManager.UpdateRecord();
        m_scoreText.text = m_scoreManager.score.ToString();
        m_backMainMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.SetActive(true);
    }

    private void OnClicked()
    {        
        m_gameStateMachine.Enter<MainMenuState>();
    }

    public override void Exit()
    {
        m_gameOverPanel.SetActive(false);
    }
}

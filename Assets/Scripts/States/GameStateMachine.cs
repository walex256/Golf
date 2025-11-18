using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private MainMenuState m_MainMenuState;

     [SerializeField] private GamplayState m_GamplayState;

    [SerializeField] private BootstrapState m_BootstrapState;

    private void Awake()
    {
        m_MainMenuState.Initialize(this);
        m_GamplayState.Initialize(this);
        m_BootstrapState.Initialize(this);
    }
    private void Start()
    {
        Enter<BootstrapState>();
    }
    public void Enter<T>()
    {
        if (typeof(T) == typeof(GamplayState))
        {
            m_GamplayState.Enter();
        }
        else if (typeof(T) == typeof(BootstrapState))
        {

        }
    }
}

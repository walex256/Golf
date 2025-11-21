using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private StateBase[] m_stateBase;

    private StateBase m_currentState;

    

    private void Awake()
    {
        foreach (StateBase state in m_stateBase)
        {
            state.Init(this);
        }
    }

    private void Start() => Enter<BootstrapState>();

    public void Enter<T>()
    {
        m_currentState?.Exit();
        foreach (StateBase state in m_stateBase)
        {
           if (state.GetType()== typeof(T))
           {
                m_currentState = state;
                state.Enter();                
           }
        }        
    }
}

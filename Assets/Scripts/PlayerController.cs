using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FreeCamera m_camera;
    [SerializeField] private GameObject m_window;
    [SerializeField] private CloudController m_cloud;
    private WeaponSwitcher[] m_switchers;
    
    private void Start()
    {        
        m_switchers = FindObjectsOfType<WeaponSwitcher>();
    }

    private void Update()
    {
        if(m_window.activeSelf)
        {
            return;
        }
        m_camera.Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_cloud.MoveNext();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchAllWeapons();
        }
    }

    private void SwitchAllWeapons()
    {
        foreach (var switcher in m_switchers)
        {
            switcher?.SwitchWeapon();
        }
    }
}
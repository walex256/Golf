using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [Header("Префабы предметов")]
    [SerializeField] private  GameObject[] m_weapons; 

    [Header("Точка в руке")]
    [SerializeField] private Transform m_hand;

    [Header("Текущий предмет")]
    [SerializeField] private GameObject m_currentWeapon;

    private int m_currentIndex = 0;

    private void Start()
    {        
        if (m_weapons.Length > 0)
        {
            SpawnWeapon(0);
        }
    }    

    public void SwitchWeapon()
    {
        if (m_weapons.Length == 0) return;
        
        if (m_currentWeapon != null)
        {
            Destroy(m_currentWeapon);
        }
        
        m_currentIndex++;
        if (m_currentIndex >= m_weapons.Length)
        {
            m_currentIndex = 0; 
        }
       
        SpawnWeapon(m_currentIndex);
    }

    void SpawnWeapon(int index)
    {
        m_currentWeapon = Instantiate(m_weapons[index], m_hand);
        m_currentWeapon.transform.localPosition = Vector3.zero;
        m_currentWeapon.transform.localRotation = Quaternion.identity;
    }
}
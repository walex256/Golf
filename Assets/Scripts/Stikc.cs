using UnityEngine;

public class Stikc : MonoBehaviour
{
    [SerializeField] private float m_minAngelZ= -30;
    [SerializeField] private float m_maxAngelZ 30;
    [SerializeField] private float m_speed;
    private void Update()
    {

        var angels = transform.localEulerAngles.z;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angels.z = Mathf.MoveTowardsAngle(angels.z, m_minAngelZ, m_maxAngelZ, m_speed * Time.deltaTime);
        }
        else
        {
    
        }

            
         

       
    }
       
}



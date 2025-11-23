using Golf;
using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Stone : MonoBehaviour
{
    [SerializeField] private StoneData[] m_data;    

    public event Action<Stone> Hit;

    public event Action<Stone> Missed;

    private Rigidbody m_Rigidbody;    

    public int score { get; private set; }

    private void Awake()
    {        
        m_Rigidbody = GetComponent<Rigidbody>();
        score = m_data[UnityEngine.Random.Range (0, m_data.Length)].score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stick>())
        {            
            Hit?.Invoke(this);
        }
        else
        {
            Missed?.Invoke(this);
        }
    }
    public void AddForce (Vector3 power)
    {
        m_Rigidbody.AddForce(power, ForceMode.Force);
    }

}

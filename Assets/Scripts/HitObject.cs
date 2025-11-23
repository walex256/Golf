using Golf;
using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class HitObject : MonoBehaviour
{
    [SerializeField] private StoneData[] m_data;

    private ScoreManager m_scoreManager;

    public event Action<HitObject> Hit;

    public event Action<HitObject> Missed;

    private Rigidbody m_Rigidbody;    

    public int score { get; private set; }

    private void Awake()
    {        
        m_Rigidbody = GetComponent<Rigidbody>();
        score = m_data[UnityEngine.Random.Range (0, m_data.Length)].score;
    }
    private void OnEnable()
    {
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stick>())
        {
            if (gameObject.layer == 9 && m_scoreManager.score < 15)
            {
                m_scoreManager.Reset();
                return;
            }
            Hit?.Invoke(this);
        }
        else
        {
            if (gameObject.layer == 9) return; 
            Missed?.Invoke(this);
        }
    }
    public void AddForce (Vector3 power)
    {
        m_Rigidbody.AddForce(power, ForceMode.Force);
    }

}

using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;
    public event Action<int> RecordChange;

    private int m_score;
    private int m_record;

    public int record
    {
        get => m_record;
        private set
        {
            if (value > m_record)
            {
                m_record = value;
                PlayerPrefs.SetInt(GlobalConst.Record, value);
                PlayerPrefs.Save(); 
                RecordChange?.Invoke(value);
            }
        }
    }

    public int score
    {
        get => m_score;
        private set
        {
            m_score = value;
            Debug.Log($"Score {value}");
            ScoreChanged?.Invoke(value);
        }
    }

    private void Start()
    {        
        m_record = PlayerPrefs.GetInt(GlobalConst.Record, 0);        
    }

    public void Increase(int value) => score += value;

    public void UpdateRecord()
    {
        record = score;         
    }

    public void Reset()
    {
        score = 0;
    }
}
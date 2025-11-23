using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;
    public event Action<int> RecordChange;

    private int m_score;
    public int record 
    {
        get
        {
            PlayerPrefs.DeleteKey(GlobalConst.Record);
            return PlayerPrefs.GetInt(GlobalConst.Record, 100);
        } 
        private set
        {            
            if (record < value)
            {
                PlayerPrefs.SetInt(GlobalConst.Record, score);
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
            ScoreChanged?.Invoke( value );
        }
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

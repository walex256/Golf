using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int m_score;
    public  int Score 
    { 
        get => m_score; 
        private set
        {
            m_score = value;
            ScoreChanged?.Invoke(value);
        } 
    }
    public void Increase()
    {
        Score++;
    }

    public void Reset()
    {
        Score = 0;
    }
}

using System;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class RecordText : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private string m_format;

    private void OnValidate()
    {
        if (!m_Text)
        {
            m_Text = GetComponent<TMP_Text>();
        }
    }

    private void OnEnable()
    {
        OnRecordChanged(m_scoreManager.score);
        m_scoreManager.RecordChange += OnRecordChanged;
    }
    private void OnDisable() => m_scoreManager.RecordChange -= OnRecordChanged;
    

    private void OnRecordChanged(int value)
    {
       m_format ??=  string.Empty;
        m_Text.text = string.Format(m_format, ToString());
    }

    
}

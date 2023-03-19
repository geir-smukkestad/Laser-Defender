using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{    
    int m_score;

    public int GetScore()
    {
        return m_score;
    }

    public void AddScore(int scoreToAdd)
    {
        m_score += scoreToAdd;
        Mathf.Clamp(m_score, 0, int.MaxValue);
        Debug.Log(m_score);
    }

    public void ResetScore()
    {
        m_score = 0;
    }
}

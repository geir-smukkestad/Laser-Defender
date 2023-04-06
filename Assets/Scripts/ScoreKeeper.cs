using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{    
    int m_score;
    static ScoreKeeper s_instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(s_instance);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

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

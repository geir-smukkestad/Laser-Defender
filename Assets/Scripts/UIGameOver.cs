using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_scoreText;
    ScoreKeeper m_scoreKeeper;

    void Awake()
    {
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        m_scoreText.text = m_scoreKeeper.GetScore().ToString();
    }
}

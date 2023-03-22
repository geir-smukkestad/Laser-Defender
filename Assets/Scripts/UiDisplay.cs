using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDisplay : MonoBehaviour
{
    [SerializeField] Slider m_slider;
    [SerializeField] TextMeshProUGUI m_scoreText;
    ScoreKeeper m_scoreKeeper;
    Health m_health;

    void Start()
    {
        m_scoreText.text = 0.ToString();
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();

        Player player = FindObjectOfType<Player>();
        m_health = player.GetComponent<Health>();
        m_slider.minValue = 0;
        m_slider.maxValue = m_health.GetHealth();
    }

    void Update()
    {
        m_scoreText.text = m_scoreKeeper.GetScore().ToString("000000000");
        m_slider.value = m_health.GetHealth();
    }
}

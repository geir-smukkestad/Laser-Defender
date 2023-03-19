using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool m_isPlayer = false;
    [SerializeField] int m_health = 50;
    [SerializeField] int m_score = 50;
    [SerializeField] ParticleSystem m_hitEffect;

    [SerializeField] bool m_applCameraShake = false;
    CameraShake m_cameraShake;
    AudioPlayer m_audioPlayer;
    ScoreKeeper m_scoreKeeper;

    void Awake()
    {
        m_cameraShake = Camera.main.GetComponent<CameraShake>();
        m_audioPlayer = FindObjectOfType<AudioPlayer>();
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return m_health;
    }

    void TakeDamage(int damage)
    {
        m_health -= damage;
        m_audioPlayer.PlayDamageClip();
        if (m_health <= 0)
            Die();
    }

    void Die()
    {
        if (!m_isPlayer)
            m_scoreKeeper.AddScore(m_score);
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (m_hitEffect != null)
        {
            ParticleSystem instance = Instantiate(m_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (m_cameraShake != null && m_applCameraShake)
            m_cameraShake.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int m_health = 50;
    [SerializeField] ParticleSystem m_hitEffect;

    [SerializeField] bool m_applCameraShake = false;
    CameraShake m_cameraShake;

    void Awake()
    {
        m_cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagerDealer = other.GetComponent<DamageDealer>();
        if (damagerDealer != null)
        {
            TakeDamage(damagerDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damagerDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        m_health -= damage;
        if (m_health <= 0)
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

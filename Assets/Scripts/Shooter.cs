using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject m_projectilePrefab;
    [SerializeField] float m_projectileSpeed = 10f;
    [SerializeField] float m_projectileLifetime = 5f;
    [SerializeField] float m_firingRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool m_useAI = false;
    [SerializeField] float m_firingRateVariance = 0.0f;
    [SerializeField] float m_minimumFiringRate = 0.1f;    

    Coroutine m_firingCoroutine;
    AudioPlayer m_audioPlayer;

    [HideInInspector]
    public bool m_isFiring;
    
    void Awake()
    {
        m_audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (m_useAI)
            m_isFiring = true;
    }

    void Update()
    {
        Fire();        
    }

    void Fire()
    {
        if (m_isFiring)
        {
            if (m_firingCoroutine == null)
                m_firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (m_firingCoroutine != null)
        {
            StopCoroutine(m_firingCoroutine);
            m_firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(m_projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
                rigidBody.velocity = transform.up * m_projectileSpeed;
            
            Destroy(projectile, m_projectileLifetime);

            float timeToNextProjectile = Random.Range(m_firingRate - m_firingRateVariance, m_firingRate + m_firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, m_minimumFiringRate, float.MaxValue);            

            m_audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}

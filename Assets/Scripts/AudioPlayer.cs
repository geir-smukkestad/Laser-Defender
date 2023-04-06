using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip m_shootingClip;
    [SerializeField] [Range(0,1f)] float m_shootingVolume = 1f;
    [SerializeField] AudioClip m_damageClip;
    [SerializeField] [Range(0,1f)] float m_damageVolume = 1f;

    static AudioPlayer s_instance;

    public void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {        
        if (s_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(m_shootingClip, m_shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(m_damageClip, m_damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}

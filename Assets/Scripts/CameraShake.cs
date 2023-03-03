using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_shakeDuration = 1f;
    [SerializeField] float m_shakeMagnitude = 0.5f;
    Vector3 m_initialPosition;

    void Start()
    {
        m_initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());        
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < m_shakeDuration)
        {
            transform.position = m_initialPosition + (Vector3)Random.insideUnitCircle * m_shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = m_initialPosition;
    }
}

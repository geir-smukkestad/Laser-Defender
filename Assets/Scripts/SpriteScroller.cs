using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 m_moveSpeed;

    Vector2 m_offset;
    Material m_material;

    void Awake()
    {
        m_material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        m_offset = m_moveSpeed * Time.deltaTime;
        m_material.mainTextureOffset += m_offset;
    }
}

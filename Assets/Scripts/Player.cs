using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 5f;
    [SerializeField] float m_paddingLeft;
    [SerializeField] float m_paddingRight;
    [SerializeField] float m_paddingTop;
    [SerializeField] float m_paddingBottom;

    Vector2 m_rawInput;
    Vector2 m_minBounds;
    Vector2 m_maxBounds;

    void Start()
    {
        InitBounds();    
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        m_minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        m_maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

     void Move()
    {
        Vector2 delta = m_rawInput * m_moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, m_minBounds.x + m_paddingLeft, m_maxBounds.x - m_paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, m_minBounds.y + m_paddingBottom, m_maxBounds.y - m_paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        m_rawInput = value.Get<Vector2>();
        Debug.Log(m_rawInput);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner m_enemySpawner;
    WaveConfigSO m_waveConfig;
    List<Transform> m_waypoints;
    int m_waypointIndex = 0;

    void Awake()
    {
        m_enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        m_waveConfig = m_enemySpawner.GetCurrentWave();
        m_waypoints = m_waveConfig.GetWaypoints();
        transform.position = m_waypoints[m_waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (m_waypointIndex < m_waypoints.Count)
        {
            Vector3 targetPosition = m_waypoints[m_waypointIndex].position;
            float delta = m_waveConfig.GetMoveSpeed() * Time.deltaTime; 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                m_waypointIndex++;
            }
        }
        else
            Destroy(gameObject);
    }
}

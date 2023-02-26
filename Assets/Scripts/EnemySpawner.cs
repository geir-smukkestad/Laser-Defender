using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO m_currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return m_currentWave;
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < m_currentWave.GetEnemyCount(); i++)
        {
            Instantiate(m_currentWave.GetEnemyPrefab(i), m_currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
        }
    }
}

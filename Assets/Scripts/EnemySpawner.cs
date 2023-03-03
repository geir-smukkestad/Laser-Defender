using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> m_waveConfigs;
    [SerializeField] float m_timeBetweenWaves = 0f;
    [SerializeField] bool m_isLooping = true;
    WaveConfigSO m_currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return m_currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in m_waveConfigs)
            {
                m_currentWave = wave;
                for (int i = 0; i < m_currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(m_currentWave.GetEnemyPrefab(i), m_currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(m_currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(m_timeBetweenWaves);
            }
        } while (m_isLooping);
    }
}

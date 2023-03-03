using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> m_enemyPrefabs;
    [SerializeField] Transform m_pathPrefab;
    [SerializeField] float m_moveSpeed = 5f;
    [SerializeField] float m_timeBetweenEnemySpawns = 1f;
    [SerializeField] float m_spawnTimeVariance = 0.2f;
    [SerializeField] float m_minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return m_pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in m_pathPrefab)
            waypoints.Add(child);
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return m_moveSpeed;
    }

    public int GetEnemyCount()
    {
        return m_enemyPrefabs.Count;        
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return m_enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(m_timeBetweenEnemySpawns - m_spawnTimeVariance,
            m_timeBetweenEnemySpawns + m_spawnTimeVariance);
        return Mathf.Clamp(spawnTime, m_minimumSpawnTime, float.MaxValue);
    }
}

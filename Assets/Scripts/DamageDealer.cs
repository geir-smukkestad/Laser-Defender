using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int m_damage = 10;

    public int GetDamage()
    {
        return m_damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}

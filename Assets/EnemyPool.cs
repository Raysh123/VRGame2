using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    public List<GameObject> pooledEnemies;
    public GameObject enemy;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemy);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy) return pooledEnemies[i];
        }

        return null;
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;
    public List<GameObject> pooledEnemies;

    [SerializeField] private Transform enemyTarget;
    
    private List<SpawnPoint> _spawnPoints;
    public GameObject enemy;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
        pooledEnemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            tmp = Instantiate(enemy);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }
    }

    private Transform GetAvailableSpawnPoint()
    {
        foreach (SpawnPoint sp in _spawnPoints)
        {
            if (sp.IsAvailable)
            {
                sp.IsAvailable = false;
                return sp.transform;
            }
        }

        return null;
    }
    
    private GameObject GetPooledEnemy()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy) return pooledEnemies[i];
        }

        return null;
    }

    public void SpawnEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        if (enemy != null)
        {
            Transform spawnPointTransform = GetAvailableSpawnPoint();
            enemy.transform.position = spawnPointTransform.position;
            enemy.GetComponentInChildren<Enemy>().Target = enemyTarget;
            enemy.SetActive(true);
        }
    }
}

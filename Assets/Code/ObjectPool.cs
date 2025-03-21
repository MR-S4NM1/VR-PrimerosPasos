using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] protected List<GameObject> _enemiesPool;

    [SerializeField] protected GameObject _enemyPrefab;

    [SerializeField] protected int _numberOfEnemies;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PreparePool();

        GameObject newEnemy = GetPooledEnemy();
        if (newEnemy != null)
        {
            newEnemy.SetActive(true);
        }
    }

    protected void PreparePool()
    {
        for (int i = 0; i < _numberOfEnemies; ++i)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.SetActive(false);
            _enemiesPool.Add(enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        print("A");
        for (int i = _enemiesPool.Count - 1; i > 0; --i)
        {
            if (!_enemiesPool[i].gameObject.activeInHierarchy)
            {
                print("B");
                return _enemiesPool[i].gameObject;
            }
        }

        return null;
    }

}

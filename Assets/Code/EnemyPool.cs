using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool enemyPool;

    protected List<GameObject> enemiesList;
    [SerializeField] protected GameObject _enemyPrefab;

    [SerializeField] protected int _numberOfEnemies;
    void Start()
    {
        enemiesList = new List<GameObject>();
    }
    void Update()
    {
        
    }
}

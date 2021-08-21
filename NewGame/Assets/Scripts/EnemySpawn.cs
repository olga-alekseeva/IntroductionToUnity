using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawnPlace;

    private GameObject _enemy;





    void Start()
    {

    }

    void Update()
    {
        if (_enemy == null)
        {

            _enemy = Instantiate(enemyPrefab, enemySpawnPlace.position, enemySpawnPlace.rotation) as GameObject;
          
        }
    }
}
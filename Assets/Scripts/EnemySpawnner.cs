using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
    }
}

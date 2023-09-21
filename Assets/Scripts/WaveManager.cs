using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform basicEnemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private int spawnCount;

    private void Awake()
    {
        spawnCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnCount = Random.Range(1, 5);
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for(int i = 1; i <= spawnCount; i++)
        {
            Instantiate(basicEnemyPrefab, spawnPoint.position, basicEnemyPrefab.rotation, transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

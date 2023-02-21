using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;

    [SerializeField] float WaveSpawnFrequency;

    [SerializeField] int minSpawn = 2;
    [SerializeField] int maxSpawn = 10;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= WaveSpawnFrequency)
        {
            SpawnWave();
            timer = 0;
        }
    }

    void SpawnWave()
    {
        int amount = Random.Range(minSpawn, maxSpawn + 1);
        float anglePerEnemy = 360 / amount;
        for (int i = 0; i < amount; i++)
        {
            GameObject gameObject = Instantiate(EnemyPrefab, transform);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, anglePerEnemy * i);
        }
    }
}

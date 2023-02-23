using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;

    [SerializeField] float WaveSpawnFrequency;

    [SerializeField] int minSpawn = 2;
    [SerializeField] int maxSpawn = 10;

    [SerializeField] int TimeToLevelUp = 15;

    [SerializeField] AnimationCurve WaveDependendSpawnFrequency;
    [SerializeField] TextMeshProUGUI levelNumber;
    float timer = 0;
    int Level = 0;
    float levelTimer = 0;
    bool levelChangeInProgress = false;

    void Update()
    {
        levelTimer += Time.deltaTime;
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

        if (levelTimer >= TimeToLevelUp)
        {
            CameraShaker.Instance.ChangeLevel();
            Level++;
            ScoreManager.Instance.LevelScoreBooster = Level;
            WaveSpawnFrequency = WaveDependendSpawnFrequency.Evaluate(Level);
            levelTimer = 0;
            levelNumber.text = Level.ToString();
        }
    }
}

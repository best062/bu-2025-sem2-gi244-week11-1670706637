using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave 
{
    public int totalSpawnEnemies;
    public int numberOfRandomSpawnPoint;
    public float delayStart;
    public float spawnInterval;
    public int numberOfPowerUp;
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Configuration")]
    public Wave[] waves;

    [Header("References")]
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public Transform[] allSpawnPoints;

    void Start()
    {
        StartCoroutine(SpawnWavesRoutine());
    }

    private IEnumerator SpawnWavesRoutine()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            Wave currentWave = waves[i];
            SpawnPowerUps(currentWave.numberOfPowerUp);
            List<Transform> selectedSpawnPoints = GetRandomSpawnPoints(currentWave.numberOfRandomSpawnPoint);
            yield return new WaitForSeconds(currentWave.delayStart);
            
            for (int j = 0; j < currentWave.totalSpawnEnemies; j++)
            {
                Transform spawnPoint = selectedSpawnPoints[Random.Range(0, selectedSpawnPoints.Count)];
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }
            
            yield return new WaitForSeconds(2f);
        }
    }
    
    private List<Transform> GetRandomSpawnPoints(int count)
    {
        List<Transform> availablePoints = new List<Transform>(allSpawnPoints);
        List<Transform> selectedPoints = new List<Transform>();
        count = Mathf.Min(count, availablePoints.Count);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);
            selectedPoints.Add(availablePoints[randomIndex]);
            
            availablePoints.RemoveAt(randomIndex); 
        }
        return selectedPoints;
    }
    
    private void SpawnPowerUps(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform randomPoint = allSpawnPoints[Random.Range(0, allSpawnPoints.Length)];
            Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            Instantiate(powerUpPrefab, randomPoint.position + randomOffset, Quaternion.identity);
        }
    }
}
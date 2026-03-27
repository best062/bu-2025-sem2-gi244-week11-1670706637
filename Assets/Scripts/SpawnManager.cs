using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating(nameof(RandomSpawn),0,1f);
        StartCoroutine(Hello());
        StartCoroutine(Goodbye());
        StartCoroutine(SpawnRoutine());
    }

    void RandomSpawn()
    {
        var index = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab,spawnPoint.position, Quaternion.identity);
    }

    IEnumerator Hello()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Hello" + Time.frameCount);
    }

    IEnumerator Goodbye()
    {
        yield return null; 
        Debug.Log("Goodbye" + Time.frameCount + "          " + Time.time);
        yield return new WaitForSeconds(2f);
        Debug.Log("Goodbye" + Time.frameCount + "          " + Time.time);
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3f);
        }
    }
}

using System.Collections;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject _prefab;   
    public Transform[] spawnPoints;
    public int spawnCount;   
    public bool spawnerOn = false;
    public float interval;
    public float spawnRate;

    void Update()
    {
        if(spawnerOn)
        {
            if (spawnRate > 0)
            {
                spawnRate -= Time.deltaTime;
                UpdateTimer(spawnRate);
            }
            else
            {
                StartCoroutine(SpawnPrefab(spawnCount));
                spawnRate = 0;
                spawnerOn = false;
            }
        }
    }

 

    IEnumerator SpawnPrefab(int spawnCount)
    {
        Debug.Log("Spawning " + _prefab.name);

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoint reference");
        }
        for (int i = 0; i < spawnCount; i++)
        {
            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_prefab, _sp.position, _sp.transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
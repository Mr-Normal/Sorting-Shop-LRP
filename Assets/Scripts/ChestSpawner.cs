using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    [Range(1, 100)] public float maxInterval = 25;
    [Range(1, 100)] public float minInterval = 20;

    float timeToSpawn;

    void Update()
    {
        TrySpawn();
    }

    void TrySpawn()
    {
        if(timeToSpawn > 0)
        {
            timeToSpawn -= Time.deltaTime;
        }
        else
        {
            timeToSpawn = GetRandomInterval();
            Spawn(GetRandomPrefab(prefabs));
        }
    }

    void Spawn(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, transform, false);
        go.name = prefab.name;
    }

    static GameObject GetRandomPrefab(GameObject[] prefabs)
    {
        int iRandom = Random.Range(0, prefabs.Length);
        return prefabs[iRandom];
    }

    float GetRandomInterval()
    {
        return Random.Range(minInterval, maxInterval);
    }
}

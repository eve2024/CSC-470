using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> foodPrefabs;
    public List<GameObject> trashPrefabs;
    public float spawnInterval = 2f;
    public float spawnHeight = 10f;
    public float groundSize = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 1f, spawnInterval);
    }

    void SpawnItem()
    {
        float x = Random.Range(-groundSize / 2, groundSize / 2);
        float z = Random.Range(-groundSize / 2, groundSize / 2);
        Vector3 spawnPosition = new Vector3(x, spawnHeight, z);
        GameObject prefab;

        if (Random.value > 0.5f)
        {

            if (foodPrefabs.Count > 0)
            {
                prefab = foodPrefabs[Random.Range(0, foodPrefabs.Count)];

            } 
            else
            {
                return;
            }
        }
        else 
        {
            if (trashPrefabs.Count > 0)
            {
                prefab = trashPrefabs[Random.Range(0, trashPrefabs.Count)];
            }
            else
            {
                return;
            }
        }

        Instantiate(prefab, new Vector3(x, spawnHeight, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

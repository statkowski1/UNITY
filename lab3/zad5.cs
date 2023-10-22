using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float spawnAreaSize = 10f;

    void Start()
    {
        for(int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spawnAreaSize, spawnAreaSize), 5f, Random.Range(-spawnAreaSize, spawnAreaSize));
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}

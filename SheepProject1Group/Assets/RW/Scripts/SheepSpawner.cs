using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheep;
    [SerializeField] private Vector3 spawnPointPosition;
    [SerializeField] private Vector2 boundary;
    [SerializeField] private float spawnRate;





    void Start()
    {
        StartCoroutine(SpawnSheep());
    }

    void CreateSheep()
    {
        float xRandom = Random.Range(boundary.x, boundary.y);
        spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z); 
        Instantiate(sheep, spawnPointPosition, sheep.transform.rotation);
    }

    IEnumerator SpawnSheep()
    {
        yield return new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            CreateSheep();
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject sheepPrefab;
    [SerializeField] private Vector3 spawnPointPosition;
    [SerializeField] private Vector2 boundary;

    [SerializeField] private float spawnRate;
    [SerializeField] private float waveRate;

    [SerializeField] private int sheepCount;
    [SerializeField] private int waveCount;


    [SerializeField] private List<SheepProperty> sheepProperties;

    void Start()
    {
        StartCoroutine(SpawnSheep());
    }

    void CreateSheep()
    {
        float xRandom = Random.Range(boundary.x, boundary.y);
        spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z);

        GameObject sheep = ObjectPooler.objectPoller.GetPooledObject();
        if(sheep == null) { return; }

        sheep.transform.position = spawnPointPosition;
        sheep.SetActive(true);

       // GameObject sheep = Instantiate(sheepPrefab, spawnPointPosition, sheepPrefab.transform.rotation);


        int randomSheepPropertyIndex = Random.Range(0, sheepProperties.Count);
        sheep.GetComponent<SheepController>().SetPropertyToSheep(sheepProperties[randomSheepPropertyIndex]);
    }

    

    IEnumerator SpawnSheep()
    {
        yield return new WaitForSeconds(spawnRate);
        while (waveCount > 0)
        {
            for (int i = 0; i < sheepCount; i++)
            {
                yield return new WaitForSeconds(spawnRate);
                CreateSheep();
            }

            sheepCount += 5; //увеличение на след волне
            waveCount--;
            yield return new WaitForSeconds(waveRate);      
        }

        Debug.Log("Finish. You win.");
    }
  
}

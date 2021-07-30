using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler objectPoller;

    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int pooledAmount;
    [SerializeField] private bool willGrow;

    [SerializeField] List<GameObject> pooledObjects;




    private void Awake()
    {
        objectPoller = this;
    }


    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            pooledObjects.Add(Instantiate(pooledObject));
            pooledObjects[i].transform.SetParent(transform);
            pooledObjects[i].SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) // pooledObjects[i].activeInHierarchy == false
            {
                return pooledObjects[i];
            }
        }

        if (willGrow) // willGrow == true
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            obj.transform.SetParent(transform);
            return obj;
        }

        return null;      
    }
}

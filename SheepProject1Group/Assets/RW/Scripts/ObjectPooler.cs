using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //ccылки будут редактируемые
public class ObjectPoolItem
{
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
}


public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler objectPoller;
    [SerializeField] private List<ObjectPoolItem> itemsToPool;
    [SerializeField] private List<GameObject> pooledObjects;


    private void Awake()
    {
        objectPoller = this;
    }


    void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.pooledAmount; i++)
            {
                pooledObjects.Add(Instantiate(item.pooledObject));
                pooledObjects[i].transform.SetParent(transform);
                pooledObjects[i].SetActive(false);
            }
        }

    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) // pooledObjects[i].activeInHierarchy == false
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.pooledObject.tag == tag)
            {
                if (item.willGrow) // willGrow == true
                {
                    GameObject obj = Instantiate(item.pooledObject);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    obj.transform.SetParent(transform);
                    return obj;
                }
            }
        }
       
        return null;      
    }
}

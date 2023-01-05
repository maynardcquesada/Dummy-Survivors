using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolingSystem : MonoBehaviour
{
    public static ObjectPoolingSystem instance;
    
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 8;

    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (var i = 0; i < amountToPool; i++)
        {
            var obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var t in pooledObjects)
        {
            if (!t.activeInHierarchy)
            {
                return t;
            }
        }

        return null;
    }
}

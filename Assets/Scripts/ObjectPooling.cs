using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string objectTag;
        public GameObject prefab;
        public int size;
    }

    //create the list
    public List<Pool> pools;

    //Creating the dictionary
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton

    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //add list of pools to the dictionary
        foreach (Pool pool in pools)
        {
            //create a queue of objects
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
               GameObject obj =  Instantiate(pool.prefab);
                obj.SetActive(true);
                objectPool.Enqueue(obj);
            }   

            poolDictionary.Add(pool.objectTag, objectPool);   
        }

        // Debug the pool dictionary
        Debug.Log("Pool Dictionary: " + poolDictionary.Count + " pools loaded");

    }

    //spawn objects from the top of the pool at a random position 
    public GameObject spawnFromPool(string objectTag, Vector3 postition, Quaternion rotation)
    {
        if (poolDictionary[objectTag].Count == 0)
        {
            Debug.LogWarning("No objects left in pool for tag: " + objectTag);
            return null;
        }

        if (!poolDictionary.ContainsKey(objectTag))
        {
            Debug.LogWarning($"Pool with tag {objectTag} does not exist");
            return null;
        }



        GameObject objectToSpawn = poolDictionary[objectTag].Dequeue();
        //objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = postition;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    //return objects to the pool after they fall out of the screeen or are collected or they hit the bottom boundary
    public void ReturnToPool(string objectTag, GameObject obj)
    {
        //obj.SetActive(false);
        poolDictionary[objectTag].Enqueue(obj);
    }
  
}

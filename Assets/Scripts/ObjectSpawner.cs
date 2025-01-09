using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Ensure the objects (both good and bad) spawn from random location at the top of the screen)

    [System.Serializable]
    public class SpawnData
    {
        public float spawnInterval;
        public string objectTag;
    }

    public SpawnData[] spawnDataArray;
    private float spawnHeight = -5.7f;
    private float spawnRange = 21;

    //public Camera mainCamera;

    private void Start()
    {
        spawnBounds();

        if (spawnDataArray == null || spawnDataArray.Length == 0)
        {
            Debug.LogError("SpawnData array is empty or not assigned!");
            return;
        }

        //loop through the array to start the indivigual spawn process for each tag
        foreach (var spawnData in spawnDataArray)
        {
            StartCoroutine(SpawnRoutine(spawnData));
        }

    }

    private void spawnBounds()
    {
        //get the top and horizontal bounds of the main camera viewport
        //spawnHeight = mainCamera.orthographicSize + 1f;
        //spawnRange = mainCamera.orthographicSize * mainCamera.aspect;

        // Draw lines to visualize the spawn area
        Debug.DrawLine(new Vector3(-spawnRange, spawnHeight, 0), new Vector3(spawnRange, spawnHeight, 0), Color.green, 5f);
       
    }

    public IEnumerator SpawnRoutine(SpawnData spawnData)
    {
        while (true)
        {
            //randomise the x position of the object within the range
            float randomX = Random.Range(-spawnRange, spawnRange);

            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

            //spawn object from the pool
            Debug.Log($"Spawning object with tag: {spawnData.objectTag}");

            GameObject spawnedObject = ObjectPooling.Instance.spawnFromPool(spawnData.objectTag, spawnPosition, Quaternion.identity);
            if (spawnedObject == null)
            {
                Debug.LogWarning($"Failed to spawn object with tag: {spawnData.objectTag}");
            }

            //wait for the specfied interval before spawning the next object of the tag
            yield return new WaitForSeconds(spawnData.spawnInterval);
        }
    }


 }

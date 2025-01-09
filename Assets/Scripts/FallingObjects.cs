using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObjects : MonoBehaviour
{
    public string objectTag; //tag of object to spawn
    public float fallSpeed;
    public float bottomBoundary = 5.2f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = fallSpeed; // adjust the gravity
    }

    private void Update()
    {
        //check if the objects hit the bottom boundary
        if(transform.position.y < bottomBoundary)
        {
            ObjectPooling.Instance.ReturnToPool(objectTag, gameObject); //return object to pool
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the falling object collides with the basket
        if (collision.CompareTag("Basket"))
        {
            Debug.Log("Collides with basket");

            //if (objectTag == "GoodFruit")
            //{
            //    // Increase score for catching a good fruit
            //    ScoreManager.Instance.IncreaseScore();
            //}
            //else if (objectTag == "BadFruit")
            //{
            //    // Decrease score or penalize for catching a bad fruit
            //    ScoreManager.Instance.DecreaseScore();
            //}

            // Return the object to the pool after catching
            ObjectPooling.Instance.ReturnToPool(objectTag, gameObject);
        }
    }
}

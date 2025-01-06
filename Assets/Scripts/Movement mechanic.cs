using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movementmechanic : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    float horizontalMovement; // input action reference for movement

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        Debug.Log("Input recognized");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public Camera mainCamera;
    public float rotationSpeed;

    public float speed;
    private float horizontalMovement;
    private float verticalMovement;

    public float jumpHeight;
    private bool isGrounded = true;
    private bool isJumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = verticalMovement * mainCamera.transform.forward;
        rb.AddForce(movement * speed);

        Vector3 movementHorizontal = horizontalMovement * mainCamera.transform.right;
        rb.AddForce(movementHorizontal * speed);

        if (isJumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isJumpPressed = false;
            isGrounded = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        horizontalMovement = movementVector.x;
        verticalMovement = movementVector.y;
    }

    void OnJump()
    {
        if (isGrounded) isJumpPressed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}

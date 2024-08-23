using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform mainCamera;

    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;
    public float jumpPower;
    public float gravity;

    public float speedThisFrame;

    public Vector2 inputThisFrame;

    public Vector2 movementThisFrame;

    public Rigidbody2D rb;

    public LayerMask groundedMask;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputThisFrame.x = Input.GetAxis("Horizontal");
        inputThisFrame.y = Input.GetAxis("Vertical");

        movementThisFrame = Vector2.zero;

        movementThisFrame.x = inputThisFrame.x;
        movementThisFrame.y = inputThisFrame.y;

        speedThisFrame = walkSpeed;

        if (Input.GetButton("Sprint"))
        {
            speedThisFrame = runSpeed;
        }

        if (Input.GetButton("Crouch"))
        {
            speedThisFrame = crouchSpeed;
        }

        movementThisFrame *= speedThisFrame;

        movementThisFrame.y = rb.velocity.y - gravity * Time.deltaTime;

        if (IsGrounded())
        {
            if (Input.GetButton("Jump"))
            {
                movementThisFrame.y = jumpPower;
            }
        }

        Move(movementThisFrame);
    }

    private void Move (Vector2 movement)
    {
        /*movement = mainCamera.TransformDirection(movement);
        Vector2 facingDirection = new Vector2(movement.x, 0);
        transform.up = facingDirection;*/
        
        rb.velocity = movement;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedMask);
    }

}

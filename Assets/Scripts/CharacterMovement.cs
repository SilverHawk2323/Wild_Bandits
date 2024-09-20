using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed;
    public float dashPower;
    public float crouchSpeed;
    public float jumpPower;
    public float gravity;

    public float speedThisFrame;

    public Vector2 inputThisFrame;

    public Vector2 movementThisFrame;

    public Rigidbody2D rb;

    public LayerMask groundedMask;
    public GameObject checkpoint;


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

        /*if (Input.GetButtonDown("Dash")) // feel free to comment it out or delete it 
        {
            movementThisFrame.x *= dashPower;
        }

        if (Input.GetButton("Crouch"))
        {
            speedThisFrame = crouchSpeed;
        }*/

        if (inputThisFrame.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        movementThisFrame *= speedThisFrame * 1 + Time.deltaTime;

        movementThisFrame.y = rb.velocity.y - gravity * Time.deltaTime;

        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                movementThisFrame.y = jumpPower;
            }
        }

        Move(movementThisFrame);

        if (IsGroundedGlide() == false)
        {
            if (Input.GetButton("Glide"))
            {
                rb.gravityScale = 0.5f;
            }
        }


    }

    private void Move(Vector2 movement)
    {
        rb.velocity = movement;
    }

    public void Respawn()
    {
        //instead of destroying the player the game will just move the player to a checkpoint which is an empty game object.
        transform.position = checkpoint.transform.position;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.55f, groundedMask);
    }

    private bool IsGroundedGlide()
    {
        rb.gravityScale = 1;
        return Physics2D.Raycast(transform.position, Vector2.down, 2.5f, groundedMask);
    }
}

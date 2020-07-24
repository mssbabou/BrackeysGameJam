using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script moves the player

public class PlayerMovement : MonoBehaviour
{
    //Variable allows access to the RigidBody
    Rigidbody rigidbody;

    //Variable to allow access to the Transform
    Transform transform;

    //Vector2 to store player input
    private Vector2 input;

    //Vector2 storing the normalized input as a direction
    private Vector2 direction;

    //Variable for player movement speed
    [Range(0.01f, 15f)]
    public float speed;

    //Vector2 containing direction * speed
    private Vector2 velocity;

    //Adjusted velocity vector by Time.deltaTime to balance movement speed
    private Vector2 moveAmount;



    // Start is called before the first frame update

    private void Awake()
    {
        //Sets the transform variable to the Transform on this GameObject
        transform = GetComponent<Transform>();

        //sets the variable rigidbody to the RigidBody on this GameObject
        rigidbody = GetComponent<Rigidbody>();
        
        //Sets the rigidbody to be kinematic, meaning it isnt affected by the physics engine, but can still detect collisions
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //fixes all public variables that could cause null errors
        FixNullErrors();

        //detects player input from arrow keys and WASD, and sets the input variable to a Vector2 in range (0, 0) --> (1, 1) to allow x-z movement
        HandleInput();
    }

    void FixNullErrors()
    {
        //stops the player from having a speed of 0
        if (speed <= 0)
        {
            speed = 0.01f;
        }
    }

    void HandleInput()
    {

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        direction = input.normalized;

        velocity = direction * speed;

        moveAmount = velocity * Time.deltaTime;

        //moves the player using the Vector2 moveAmount
        transform.Translate(moveAmount);

    }
}

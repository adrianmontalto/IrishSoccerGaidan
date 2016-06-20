using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;//the character controller
    private float gravityForce = 0.0f;//the force of gravity
    private float movementTimer = 0.0f;//a timer to calculate movement
    private int drunkFactor = 0;//a number for how drunk the player is
    public float movementResetTimer = 0.0f;//value to reset timer
    [Range(1.0f,10.0f)]
    public float speed = 0.0f;//the players speed
    public float gravity = 20.0f;//the players gravity
    public float randomMin = 0.0f;//the min for the player random movement
    public float randomMax = 0.0f;//the max for the player random movement
    
    // Use this for initialization
    void Start()
    {
        //gets the character controller attached to the player
        controller = gameObject.GetComponent<CharacterController>();
    }

    //checks what keys the player is pressing
    void InputCheck()
    {
        movementTimer -= Time.deltaTime;
        //checks to see whether the player is moving up or down and left or right
        float h_input = Input.GetAxis("Horizontal") * speed;
        float v_input = Input.GetAxis("Vertical") * speed;

        //checks to see if the player isn't grounded
        if (!controller.isGrounded)
        {
            //applies gravity to the playe
            gravityForce += Physics.gravity.y * gravity * Time.deltaTime;
        }

        //moves the player
        Vector3 directions = new Vector3(h_input, gravityForce, v_input);
        
        if(movementTimer < 0)
        {
            if (Input.GetButton("Up") || Input.GetButton("Down"))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input + random, gravityForce, v_input);
                movementTimer = movementResetTimer;
            }
            if (Input.GetButton("Left") || Input.GetButton("Right"))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input, gravityForce, v_input + random);
                movementTimer = movementResetTimer;
            }
        }

        controller.Move(directions * Time.deltaTime);
        //checks to see if the player is grounded
        if (controller.isGrounded)
        {
            //makes the jumpforce = nothing
            gravityForce = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //calls the input check function
        InputCheck();
    }
}
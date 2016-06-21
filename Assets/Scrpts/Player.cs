using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;//the character controller
    private float gravityForce = 0.0f;//the force of gravity
    private float movementTimer = 0.0f;//a timer to calculate movement
    private int drunkFactor = 0;//a number for how drunk the player is
    private int controllerNumber = 0;//the number for the assigned controller
    private bool isActive = false;//to determine whether the player can move
    [Range(1, 2)]
    public int playerNumber = 0;//the players number
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

    // Update is called once per frame
    void Update()
    {
        //checks to see if the player is active
        if(isActive == true)
        {
            string axisname = "J" + controllerNumber + "Horizontal";
            float xAxis = Input.GetAxis(axisname);
            string horizontalAxis = axisname;
            axisname = "J" + controllerNumber + "Vertical";
            float yAxis = Input.GetAxis(axisname);
            string verticalAxis = axisname;
            ControllerInputCheck(xAxis,yAxis,horizontalAxis,verticalAxis);
        }
        InputCheck();
    }

    //checks what keys the player is pressing
    void InputCheck()
    {
        if(playerNumber == 1)
        {
            Player1KeyboardCheck();
        }
        if(playerNumber == 2)
        {
            Player2KeyboardCheck();
        }
    }

    void ControllerInputCheck(float x, float y,string horizontal,string vertical)
    {
        movementTimer -= Time.deltaTime;
        //checks to see whether the player is moving up or down and left or right
        float h_input = x * speed;
        float v_input = y * speed;

        Vector3 facingDirection = new Vector3(h_input, 0, v_input);
        transform.LookAt(transform.position + facingDirection);

        //checks to see if the player isn't grounded
        if (!controller.isGrounded)
        {
            //applies gravity to the playe
            gravityForce += Physics.gravity.y * gravity * Time.deltaTime;
        }

        //moves the player
        Vector3 directions = new Vector3(h_input, gravityForce, v_input);

        if (movementTimer < 0)
        {
            //checks to see if the up or down button are pressed
            if (Input.GetButton(horizontal))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input + random, gravityForce, v_input);
                directions.Normalize();
                movementTimer = movementResetTimer;
            }
            if (Input.GetButton(vertical))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input, gravityForce, v_input + random);
                directions.Normalize();
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

    public void SetActive(bool active)
    {
        //sets the active bool
        isActive = active;
    }

    public void SetControllerNumber(int number)
    {
        controllerNumber = number;
    }

    void Player1KeyboardCheck()
    {
        movementTimer -= Time.deltaTime;
        
        //checks to see whether the player is moving up or down and left or right
        float h_input = Input.GetAxis("K1Horizontal") * speed;
        float v_input = Input.GetAxis("K1Vertical") * speed;

        Vector3 facingDirection = new Vector3(h_input, 0, v_input);
        transform.LookAt(transform.position + facingDirection);
        
        //checks to see if the player isn't grounded
        if (!controller.isGrounded)
        {
            //applies gravity to the playe
            gravityForce += Physics.gravity.y * gravity * Time.deltaTime;
        }
        
        //moves the player
        Vector3 directions = new Vector3(h_input, gravityForce, v_input);
        
        if (movementTimer < 0)
        {
            //checks to see if the up or down button are pressed
            //if (Input.GetButton("K1Horizontal"))
            //{
            //    float random = Random.Range(randomMin, randomMax);
            //    directions = new Vector3(h_input + random, gravityForce, v_input);
            //    directions.Normalize();
            //    movementTimer = movementResetTimer;
            //}
            //if (Input.GetButton("K1Vertical"))
            //{
            //    float random = Random.Range(randomMin, randomMax);
            //    directions = new Vector3(h_input, gravityForce, v_input + random);
            //    directions.Normalize();
            //    movementTimer = movementResetTimer;
            //}
        }
        
        controller.Move(directions * Time.deltaTime);
        //checks to see if the player is grounded
        if (controller.isGrounded)
        {
            //makes the jumpforce = nothing
            gravityForce = 0.0f;
        }
    }

    void Player2KeyboardCheck()
    {
        movementTimer -= Time.deltaTime;

        float h_input = Input.GetAxis("K2Horizontal") * speed;
        float v_input = Input.GetAxis("K2Vertical") * speed;

        Vector3 facingDirection = new Vector3(h_input, 0, v_input);
        transform.LookAt(transform.position + facingDirection);
        
        //checks to see if the player isn't grounded
        if (!controller.isGrounded)
        {
            //applies gravity to the playe
            gravityForce += Physics.gravity.y * gravity * Time.deltaTime;
        }
        
        //moves the player
        Vector3 directions = new Vector3(h_input, gravityForce, v_input);
        
        if (movementTimer < 0)
        {
            //checks to see if the up or down button are pressed
            if (Input.GetButton("K2Horizontal"))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input + random, gravityForce, v_input);
                directions.Normalize();
                movementTimer = movementResetTimer;
            }
            if (Input.GetButton("K2Vertical"))
            {
                float random = Random.Range(randomMin, randomMax);
                directions = new Vector3(h_input, gravityForce, v_input + random);
                directions.Normalize();
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
}
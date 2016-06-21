using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;//the character controller
    private float gravityForce = 0.0f;//the force of gravity
    private int controllerNumber = 0;//the number for the assigned controller
    private bool isActive = false;//to determine whether the player can move
    [Range(1, 2)]
    public int playerNumber = 0;//the players number
    [Range(1.0f,10.0f)]
    public float speed = 0.0f;//the players speed
    public float gravity = 20.0f;//the players gravity
    
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
            string axisname = "j" + controllerNumber + "Horizontal";
            float xAsis = Input.GetAxis(axisname);
            axisname = "j" + controllerNumber + "Vertical";
            float yAxis = Input.GetAxis(axisname);
            ControllerInputCheck(xAsis, yAxis);
        }
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

    void ControllerInputCheck(float x, float y)
    {
        
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

    }

    void Player2KeyboardCheck()
    {

    }
}
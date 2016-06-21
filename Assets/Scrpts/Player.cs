using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;//the character controller
    private float gravityForce = 0.0f;//the force of gravity
    private float hitTimer = 0.0f;
    private int controllerNumber = 0;//the number for the assigned controller
    private bool controllerActive = false;//to determine whether the player can move
    private Vector3 force = new Vector3(0,0,0);
    private AudioSource source;
    [Range(1, 2)]
    public int playerNumber = 0;//the players number
    [Range(1.0f,10.0f)]
    public float speed = 0.0f;//the players speed
    public float gravity = 20.0f;//the players gravity
    public float pushPower = 20.0f;
    public float hitResetTimer = 0.5f;
    public AudioClip kickSound;

    public GameObject Potato;
    // Use this for initialization
    void Start()
    {
        //gets the character controller attached to the player
        controller = gameObject.GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        hitTimer -= Time.deltaTime;
        //checks to see if the player is active
        if(controllerActive == true)
        {
            string axisname = "j" + controllerNumber + "Horizontal";
            float xAsis = Input.GetAxis(axisname);
            axisname = "j" + controllerNumber + "Vertical";
            float yAxis = Input.GetAxis(axisname);
            ControllerInputCheck(xAsis, yAxis);
        }
        if(controllerActive == false)
        {
            InputCheck();
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
        controllerActive = active;
    }

    public void SetControllerNumber(int number)
    {
        controllerNumber = number;
    }

    void Player1KeyboardCheck()
    {
        //checks to see whether the player is moving up or down and left or right
        float h_input = Input.GetAxis("K1Horizontal") *speed;
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
        //checks to see whether the player is moving up or down and left or right
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

        controller.Move(directions * Time.deltaTime);
        //checks to see if the player is grounded
        if (controller.isGrounded)
        {
            //makes the jumpforce = nothing
            gravityForce = 0.0f;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if(body == null || body.isKinematic)
        {
            return;
        }

        if(hitTimer < 0)
        {
            force = hit.controller.velocity * pushPower;
            source.PlayOneShot(kickSound,10.0f);
            hitTimer = hitResetTimer;
        }
        body.AddForceAtPosition(force, hit.point);
        source.PlayOneShot(kickSound, 1.0f);
    }
}
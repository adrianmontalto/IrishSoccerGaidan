using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private bool selectedPlayer = true;//a bool value to determine whether the player is selected
    private float movementTimer = 0.0f;//a timer to calculate movement
    public float movementResetTimer = 1.0f;//value to reset movement timer
    [Range(1.0f,10.0f)]
    public float speed = 0.0f;//the speed of the player
    public float randomMin = 0.0f;//the min for the player random movement
    public float randomMax = 0.0f;//the max for the players random movement
  	// Use this for initialization
	void Start ()
    {
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks to see if that player is selected
	    if(selectedPlayer == true)
        {
            //runs the code for player input
            ControllerMovement();
        }
        else
        {
            //runs the code for AI movement
            AiMovement();
        }
	}

    public void SetSelectedPlayer(bool isSelected)
    {
        selectedPlayer = isSelected;
    }

    void AiMovement()
    {

    }

    void ControllerMovement()
    {
        movementTimer -= Time.deltaTime;
        //checks to see if the up or down key are pressed
        if (Input.GetButton("Up") || Input.GetButton("Down"))
        {
            float h_input = Input.GetAxis("Horizontal");
            float v_input = Input.GetAxis("Vertical");            
            Vector3 direction = new Vector3(h_input, -10, v_input);
            if (movementTimer < 0)
            {
                float random = Random.Range(randomMin, randomMax);
                direction = new Vector3(h_input + random, -10, v_input);
                movementTimer = movementResetTimer;
            }
            
            //direction.Normalize();
            direction *= Time.deltaTime * speed;
            controller.Move(direction);            
        }

        //checks to see if the left or right key is down
        if (Input.GetButton("Left") || Input.GetButton("Right"))
        {
            float h_input = Input.GetAxis("Horizontal");
            float v_input = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(h_input, -10, v_input);
            if(movementTimer < 0)
            {
                float random = Random.Range(randomMin, randomMax);
                direction = new Vector3(h_input, -10, v_input + random);
                movementTimer = movementResetTimer;
            }
            //direction.Normalize();
            direction *= Time.deltaTime * speed;
            controller.Move(direction);
        }
    }
}

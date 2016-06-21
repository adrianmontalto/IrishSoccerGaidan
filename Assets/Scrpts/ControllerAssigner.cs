using UnityEngine;
using System.Collections;

public class ControllerAssigner : MonoBehaviour
{
    private bool isController1Available = true;
    private bool isController2Available = true;

    private bool isPlayer1Set = false;
    private bool isPlayer2Set = false;

    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckWhichController();
    }

    void CheckWhichController()
    {
        //checks if player 1 is available
        if (isPlayer1Set == false)
        {
            SetPlayer(player1, ref isPlayer1Set);
        }

        //checks if player 2 is available
        if (isPlayer2Set == false)
        {
            if (isPlayer1Set)
            {
                SetPlayer(player2, ref isPlayer2Set);
            }
        }
    }

    void SetPlayer(GameObject player, ref bool setPlayer)

    {
        bool isSet = false;
        if (!isSet)
        {
            //checks if controller 1 is available
            if (isController1Available)
            {
                //checks to see if the start button is pressed
                if (Input.GetButton("j1Start"))
                {
                    isController1Available = false;
                    player.GetComponent<Player>().SetControllerNumber(1);
                    player.GetComponent<Player>().SetActive(true);
                    setPlayer = true;
                }
            }

            //checks if controller 2 is available
            if (isController2Available)
            {
                //checks to see if the start button is pressed
                if (Input.GetButton("j2Start"))
                {
                    isController2Available = false;
                    player.GetComponent<Player>().SetActive(true);
                    player.GetComponent<Player>().SetControllerNumber(2);
                    setPlayer = true;
                }
            }
        }
    }
}
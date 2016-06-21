using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Drunkeness player1;
    public Drunkeness player2;

    private int player1Score = 0;
    private int player2Score = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
        if(player1Score == 5 || player2Score == 5)
        {
            GoToMenu();
        }
	}

    public void AddPlayer1Score(int score)
    {
        player1Score += score;
        player1.SetDrunkFactor(1.0f);
    }

    public void Addplayer2Score(int score)
    {
        player2Score += score;
        player2.SetDrunkFactor(1.0f);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Title");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

	// Use this for initialization

	public void LoadMain()
    {
		SceneManager.LoadScene ("Game");
	}
	public void ExitGame()
    {
		Application.Quit(); 
	}
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}

using UnityEngine;
using System.Collections;

public class Drunkeness : MonoBehaviour
{
    private CharacterController controller;
    private float xFactor = 0.0f;
    private float yFactor = 0.0f;
    private float drunkFactor = 1.0f;
    private float movementTimer = 0.0f;//a timer to calculate movement
    private float speed = 0.0f;
    public Player player;
    public float movementResetTimer = 0.0f;//value to reset timer
    private float lerpTime = 1.0f;
    public float randomMin = 0.0f;
    public float randomMax = 0.0f;

    // Use this for initialization
    void Start ()
    {
        controller = gameObject.GetComponent<CharacterController>();
        xFactor = Random.Range(randomMin * drunkFactor,randomMax * drunkFactor);
        yFactor = Random.Range(randomMin * drunkFactor,randomMax * drunkFactor);
        speed = player.speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementTimer -= Time.deltaTime;
        if(movementTimer < 0)
        {
            xFactor = Random.Range(randomMin * drunkFactor, randomMax * drunkFactor);
            yFactor = Random.Range(randomMin * drunkFactor, randomMax * drunkFactor);
            movementTimer = movementResetTimer;
        }
        float x =Mathf.Lerp(0.0f, xFactor, Mathf.Clamp((lerpTime / 10.0f), 0.0f, 10.0f));
        float y =Mathf.Lerp(0.0f, yFactor, Mathf.Clamp((lerpTime / 10.0f), 0.0f, 10.0f));
        Vector3 direction = new Vector3(x,0,y);
        controller.Move(direction * speed * Time.deltaTime); 
	}

    public void SetDrunkFactor(float increase)
    {
        drunkFactor += increase;
    }
}

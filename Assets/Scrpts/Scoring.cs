using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{


    public GameObject Potato;
    public GameObject LeftGoal;
    public GameObject RightGoal;

    private int scoreP1;

   Vector3 resetpos;

    //public Collider PotatoCol;
    // Use this for initialization
    void Start ()
    {
        Potato = GameObject.Find("Potato");
        LeftGoal = GameObject.Find("LeftGoal");
        RightGoal = GameObject.Find("RightGoal");

        resetpos = new Vector3(-1.61f, 0.1f, 1.37f);

    //  PotatoCol = GetComponent<>(Potato.collider);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //  if(Potato.collider )
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Potato")
        {
            // Destroy(Potato);

            //  Potato.transform.TransformPoint(resetpos.x,resetpos.y,resetpos.z);
            Potato.transform.position = new Vector3(resetpos.x, resetpos.y, resetpos.z);

            scoreP1 += 1;
                // object collided with something called "Ground":
                // do whatever you want: set a new direction, set a boolean variable, etc.
        }
    }
}

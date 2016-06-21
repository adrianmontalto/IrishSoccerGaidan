using UnityEngine;
using System.Collections;

public class GoalDetecter : MonoBehaviour
{
    public GameObject Potato;
    public GameObject LeftGoal;
    public GameObject RightGoal;
    public GameObject Player1;
    public GameObject Player2;

    private Vector3 PotatoStartPos = new Vector3(0,0,0);
    private Vector3 Player1StartPos = new Vector3(0, 0, 0);
    private Vector3 Player2StartPos = new Vector3(0, 0, 0);

    public int scoreP1;

   Vector3 resetpos;

    //public Collider PotatoCol;
    // Use this for initialization
    void Start ()
    {
        //sets start positions of the potato and players
        PotatoStartPos = Potato.transform.position;
        Player1StartPos = Player1.transform.position;
        Player2StartPos = Player2.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    
     void OnCollisionEnter(Collision col)
     {
        if (col.gameObject.name == "LeftGoal")
        {
            //Potato.transform.TransformPoint(resetpos.x,resetpos.y,resetpos.z);
            Potato.transform.position = PotatoStartPos;
            Player1.transform.position = Player1StartPos;
            Player2.transform.position = Player2StartPos;
        }

        if (col.gameObject.name == "RightGoal")
        {
            //Potato.transform.TransformPoint(resetpos.x,resetpos.y,resetpos.z);
            Potato.transform.position = PotatoStartPos;
            Player1.transform.position = Player1StartPos;
            Player2.transform.position = Player2StartPos;
        }
    }
}

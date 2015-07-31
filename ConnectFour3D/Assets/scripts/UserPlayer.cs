using UnityEngine;
using System.Collections;

public class UserPlayer : Player {

	public bool passedturn = false;
    

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void TurnUpdate ()
	{
		
		
		//if (passedturn == true) {
			
			GameManager.instance.nextTurn();
		//}
		
		
		base.TurnUpdate ();
	}



}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : Dynamic {

	// Use this for initialization
	void Start () {

		// allow to fire a laser
		//this.gameObject.AddComponent ("Laser");
	
	}
	
	// Update is called once per frame
	void Update () {

		// enemy specific update calls

		// get the last position
		Vector3 lastPos = transform.position;
		
		// move to target
		slerpToTarget ();
		
		// flock with other enemies
		flock ();
		
		// orient to direction of motion
		orientToMovement (lastPos);

	}
}

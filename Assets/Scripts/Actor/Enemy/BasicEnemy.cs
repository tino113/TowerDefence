using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : Dynamic {

	public void Start () {
		// allow to fire a laser
		//this.gameObject.AddComponent ("Laser");
	}

	public void Update () {
		Vector3 lastPos = transform.position; // get the last position
		slerpToTarget (); // move to target
		flock (); // flock with other enemies
		orientToMovement (lastPos); // orient to direction of motion
		checkHealth ();
	}
}

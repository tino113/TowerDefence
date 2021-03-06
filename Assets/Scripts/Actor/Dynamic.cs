﻿using UnityEngine;
using System.Collections;

public class Dynamic : Actor {

	public float movementSpeed = 0.5f;
	public float rotationSpeed = 1.0f;
	public float avoidanceFactor = 2.0f;
	public float avoidanceDistance = 1.5f;
	//public float flockWithDistance = 4.0f;

	public void Update () {
		// TODO: update calls for all dynamic actors
	}

	public void slerpToTarget (){
		Vector3 target = transform.position.normalized * targetDistance;
		transform.position = Vector3.Slerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void slerpTo (Vector3 target){
		transform.position = Vector3.Slerp (transform.position, target.normalized * targetDistance, Time.time * 0.001f * movementSpeed);
	}

	public void lerpToTarget () {
		lerpTo(transform.position.normalized * targetDistance);
	}

	public void lerpTo (Vector3 target) {
		transform.position = Vector3.Lerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void orientToMovement (Vector3 lastPos) {
		Vector3 deltaPos = lastPos - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (-deltaPos), Time.deltaTime * rotationSpeed);
	}

	public void flock () {
		float MovementFactor = Time.deltaTime * movementSpeed;

		// move away from closest actor (really basic flocking behaviours)
		foreach (GameObject actor in actorList) {

			if (actor != this.gameObject) {
				// test current position against actor
				Vector3 direction = transform.position - actor.transform.position;
				Vector3 directionNoY = direction;
				directionNoY.y = 0;

				// avoid other actors
				if (direction.magnitude <= avoidanceDistance) {
					transform.position += directionNoY * MovementFactor * avoidanceFactor;
					// if the distance is really close
					if (direction.magnitude <= avoidanceDistance * 0.1f){
						transform.position += actor.transform.position.normalized * MovementFactor;
					}
				}

				// try to match the movement of other actors
				/*if ( direction.magnitude <= flockWithDistance){
					transform.position += direction * MovementFactor * avoidanceFactor;
				}*/
			}
		}
	}
}

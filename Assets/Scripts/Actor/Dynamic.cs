﻿using UnityEngine;
using System.Collections;

public class Dynamic : Actor {

	// common attributes for all Dynamic Actors
	public float movementSpeed = 0.5f;
	public float rotationSpeed = 1.0f;
	public float avoidanceFactor = 2.0f;
	public float avoidanceDistance = 1.5f;
	//public float flockWithDistance = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// update calls for all dynamic actors
	
	}

	public void slerpToTarget (){
		Vector3 movement = -transform.position.normalized * movementSpeed;
		Vector3 target = transform.position.normalized * targetDistance;
		
		transform.position = Vector3.Slerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void slerpTo (Vector3 target){
		Vector3 movement = -transform.position.normalized * movementSpeed;		
		transform.position = Vector3.Slerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void lerpToTarget (){
		Vector3 movement = -transform.position.normalized * movementSpeed;
		Vector3 target = transform.position.normalized * targetDistance;
		
		transform.position = Vector3.Lerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}
	
	public void lerpTo (Vector3 target){
		Vector3 movement = -transform.position.normalized * movementSpeed;		
		transform.position = Vector3.Lerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void orientToMovement (Vector3 lastPos) {

		Vector3 deltaPos = lastPos - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (-deltaPos), Time.deltaTime * rotationSpeed);

	}

	public void flock (){
		// move away from closest enemy (really basic flocking behaviours)
		foreach (GameObject enemy in SpawnEnemies.enemyList) {
			
			if (enemy != this.gameObject){
				// test current position against enemy
				Vector3 direction = transform.position - enemy.transform.position;
				
				// avoid other enemies
				if ( direction.magnitude <= avoidanceDistance){
					transform.position += direction * Time.deltaTime * movementSpeed * avoidanceFactor;
				}
				
				// try to match the movement of other enemies
				/*if ( direction.magnitude <= flockWithDistance){
					transform.position += direction * Time.deltaTime * movementSpeed * avoidanceFactor;
				}*/
				
				// if the distance is really close
				if (direction.magnitude <= avoidanceDistance * 0.1f){
					Vector3 randomDir = new Vector3(Random.Range(-1.0f,1.0f),0,Random.Range(-1.0f,1.0f));
					transform.position += enemy.transform.position.normalized * Time.deltaTime * movementSpeed;
				}
			}
		}
	}
}

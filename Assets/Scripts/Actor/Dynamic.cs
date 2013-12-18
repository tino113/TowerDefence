using UnityEngine;
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
		Vector3 target = transform.position.normalized * targetDistance;
		
		transform.position = Vector3.Slerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void slerpTo (Vector3 target){
		transform.position = Vector3.Slerp (transform.position, target.normalized * targetDistance, Time.time * 0.001f * movementSpeed);
	}

	public void lerpToTarget (){
		Vector3 target = transform.position.normalized * targetDistance;
		
		transform.position = Vector3.Lerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}
	
	public void lerpTo (Vector3 target){
		transform.position = Vector3.Lerp (transform.position, target, Time.time * 0.001f * movementSpeed);
	}

	public void orientToMovement (Vector3 lastPos) {

		Vector3 deltaPos = lastPos - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (-deltaPos), Time.deltaTime * rotationSpeed);

	}

	public void flock (){
		// move away from closest actor (really basic flocking behaviours)
		foreach (GameObject actor in Actor.actorList) {
			
			if (actor != this.gameObject){
				// test current position against actor
				Vector3 direction = transform.position - actor.transform.position;
				
				// avoid other actors
				if ( direction.magnitude <= avoidanceDistance){
					transform.position += direction * Time.deltaTime * movementSpeed * avoidanceFactor;
				}
				
				// try to match the movement of other actors
				/*if ( direction.magnitude <= flockWithDistance){
					transform.position += direction * Time.deltaTime * movementSpeed * avoidanceFactor;
				}*/
				
				// if the distance is really close
				if (direction.magnitude <= avoidanceDistance * 0.1f){
					transform.position += actor.transform.position.normalized * Time.deltaTime * movementSpeed;
				}
			}
		}
	}


}

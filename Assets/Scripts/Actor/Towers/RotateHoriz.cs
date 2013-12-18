using UnityEngine;
using System.Collections;

public class RotateHoriz : Tower {

	private GameObject target;
	public float rotationSpeed = 2.0f;
	[Range(1, 10)] public float turnSpeed;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per 
	void Update()
	{

		// if current target is dead pick the closest new one.
		if (target == null && Actor.actorList.Count > 0){
			float leastDist = 99999999999.0f;
			foreach (GameObject actor in Actor.actorList) {
				// if current target is not
				//if (enemy.health > 0)
				Vector3 testVec  = actor.transform.position - transform.position;
				if (testVec.magnitude < leastDist){
					target = actor;
				}
			}
		}

		if (target != null) {
			Vector3 lookDir = target.transform.position-transform.position;
			lookDir.y = 0; // keep only the horizontal direction
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * rotationSpeed);
		}

	}
}

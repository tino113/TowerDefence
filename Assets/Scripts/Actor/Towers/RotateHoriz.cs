using UnityEngine;
using System.Collections;

public class RotateHoriz : Tower {

	private GameObject target;
	[Range(1, 10)] public float turnSpeed = 2.0f;

	void Start () {

	}

	void Update() {
		// if current target is dead pick the closest new one.
		if (target == null && Actor.actorList.Count > 0) {
			float leastDist = 99999999999.0f;
			foreach (GameObject actor in Actor.actorList) {
				if (tag == "friendly" && actor.tag == "enemy" || tag == "enemy" && actor.tag == "friendly") {
					Vector3 testVec  = actor.transform.position - transform.position;
					if (testVec.magnitude < leastDist) {
						target = actor;
						leastDist = testVec.magnitude;
					}
				}
			}
		}

		if (target != null && Actor.actorList.Count > 0) {
			Vector3 lookDir = target.transform.position - transform.position;
			lookDir.y = 0; // keep only the horizontal direction
			if (lookDir.magnitude > 0) {
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * turnSpeed);
			}
		}

	}
}

using UnityEngine;
using System.Collections;

public class VerticalRotate : Tower {

	private GameObject target;
	public float rotationSpeed = 3000.0f;
	[Range(1, 10)] public float turnSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if current target is dead pick the closest new one.
		if (target == null && Actor.actorList.Count > 0){
			float leastDist = 99999999999.0f;
			foreach (GameObject actor in Actor.actorList) {
				Vector3 testVec  = actor.transform.position - transform.position;
				if (testVec.magnitude < leastDist){
					target = actor;
				}
			}
		}

		// rotate to face vertically.
		/*if (target != null) {
			Vector3 lookDir = target.transform.position-transform.position;

			lookDir.y = 0;
			Vector3 heightVec = transform.position;
			heightVec.x = 0; heightVec.z = 0;
			float rotx = Vector3.Dot( lookDir.normalized, heightVec.normalized);
			Vector3 tmpVec2 = new Vector3(0,0,270);
			tmpVec2.x = rotx; //Mathf.Lerp(transform.localRotation.x, rotx , Time.deltaTime * rotationSpeed);
			transform.localRotation = Quaternion.Euler(tmpVec2);
		}*/

		if (Actor.actorList.Count > 0) {

			// angle = dotproduct of two normalized vectors one with and one without a y component.
			// axis = cross product of those same two vectors

			Vector3 dirVec =  target.transform.position - transform.position;
			Vector3 dirVecNoY = dirVec; dirVecNoY.y = 0;

			dirVec.Normalize(); dirVecNoY.Normalize();
			float angle = Mathf.Acos(Vector3.Dot(dirVec,dirVecNoY));

			transform.localRotation = Quaternion.Slerp( transform.localRotation, Quaternion.AngleAxis( -angle*(180/Mathf.PI), Vector3.left ) * Quaternion.Euler(0.0f,0.0f,270.0f), Time.deltaTime * rotationSpeed);

			//Vector3 vertCompVec = new Vector3(0.0f,target.transform.position.y,0.0f);
			//Vector3 lookDir = vertCompVec-transform.position;
			//transform.localRotation = Quaternion.Euler(lookDir);
		}
	}

}

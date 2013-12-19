using UnityEngine;
using System.Collections;

public class VerticalRotate : Tower {

	public GameObject target;
	[Range(1, 10)] public float turnSpeed = 2.0f;

	public delegate void onTarget();
	public static event onTarget targeted;

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
				if (tag == "friendly" && actor.tag == "enemy" || tag == "enemy" && actor.tag == "friendly"){
					Vector3 testVec  = actor.transform.position - transform.position;
					if (testVec.magnitude < leastDist){
						target = actor;
						leastDist = testVec.magnitude;
					}
				}
			}
		}
		if (target != null && Actor.actorList.Count > 0){

			Vector3 dirVec =  target.transform.position - transform.position;
			Vector3 dirVecNoY = dirVec; dirVecNoY.y = 0;

			dirVec.Normalize(); dirVecNoY.Normalize();
			float angle = Mathf.Acos(Vector3.Dot(dirVec,dirVecNoY));

			Quaternion rot = Quaternion.AngleAxis( -angle*(180/Mathf.PI), Vector3.left ) * Quaternion.Euler(0.0f,0.0f,270.0f);

			transform.localRotation = Quaternion.Slerp( transform.localRotation, rot , Time.deltaTime * turnSpeed);

			if (transform.localRotation == rot )
			{
				if ( targeted != null){
					targeted();
				}
			}

		}
	}

}

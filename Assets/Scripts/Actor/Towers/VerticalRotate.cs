using UnityEngine;
using System.Collections;

public class VerticalRotate : MonoBehaviour {

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
		if (target == null){
			float leastDist = 99999999999.0f;
			foreach (GameObject enemy in SpawnEnemies.enemyList) {
				Vector3 testVec  = enemy.transform.position - transform.position;
				if (testVec.magnitude < leastDist){
					target = enemy;
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

		Vector3 vertCompVec = new Vector3(0,target.transform.position.y,0);
		Vector3 lookDir = vertCompVec-transform.position;
		transform.localRotation = Quaternion.Euler(lookDir);
	}
}

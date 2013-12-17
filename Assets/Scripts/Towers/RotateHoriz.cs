using UnityEngine;
using System.Collections;

public class RotateHoriz : MonoBehaviour {

	public GameObject target;
	[Range(1, 10)] public float turnSpeed;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per 
	void Update()
	{
		Vector3 tmpPos = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z);
		transform.LookAt(tmpPos);

	}
}

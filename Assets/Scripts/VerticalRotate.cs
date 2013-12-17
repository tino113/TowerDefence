using UnityEngine;
using System.Collections;

public class VerticalRotate : MonoBehaviour {

	public GameObject target;
	[Range(1, 10)] public float turnSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		Vector3 tmpPos = new Vector3 (target.transform.position.x+1, target.transform.position.y, target.transform.position.z+1);
		transform.LookAt(tmpPos);

	}
}

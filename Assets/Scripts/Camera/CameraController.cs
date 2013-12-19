using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float speed;

	void Start () {

	}
	
	void FixedUpdate () {
		float move_h = Input.GetAxis("Horizontal");
		float move_v = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (move_h, 0.0f, move_v);
		transform.position += movement * speed * Time.deltaTime;


	}
}

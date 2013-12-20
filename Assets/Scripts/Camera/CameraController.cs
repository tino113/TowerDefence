using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float speed;
	
	void Start () {
		
	}
	
	void FixedUpdate () {
		float horizontalMove = Input.GetAxis("Horizontal");
		float verticalMove = Input.GetAxis("Vertical");
		float mouseScroll = Input.GetAxis ("Mouse ScrollWheel");
		
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		transform.position += movement * speed * Time.deltaTime;
		
		if (mouseScroll < 0 && camera.fieldOfView < 100) {
			camera.fieldOfView = Mathf.Min(camera.fieldOfView+2, 100);
			transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(2, 0, 0), 5f);
		}
		
		if (mouseScroll > 0 && camera.fieldOfView > 40) {
			camera.fieldOfView = Mathf.Max(camera.fieldOfView-2, 40);
			transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(-2, 0, 0), 5f);
		}
	}
}

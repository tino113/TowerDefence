using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float zoomSpeed = 0.0005f;
	private float minZoom = 40;
	private float maxZoom = 100;

	//private float sensitivityDistance = 7.5f;
	//private float damping = 0.02f;

	public float moveSpeed = 10f;
	private float horizontalMove = 0f;
	private float verticalMove = 0f;

	void Update () {
		horizontalMove += Input.GetAxis("Horizontal") * moveSpeed;
		verticalMove += Input.GetAxis("Vertical") * moveSpeed;
		float mouseScroll = Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;

		float _x = Mathf.Lerp (transform.position.x, horizontalMove, Time.deltaTime);
		float _z = Mathf.Lerp (transform.position.z, verticalMove, Time.deltaTime);

		transform.position = new Vector3 (_x, 7, _z);

		if (mouseScroll > 0 && camera.fieldOfView > minZoom) { //in
			camera.fieldOfView += Mathf.Lerp( camera.fieldOfView, -mouseScroll, Time.deltaTime);
			//Mathf.Min(camera.fieldOfView+mouseScroll*zoomSpeed, minZoom);
			//transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(2, 0, 0), 5f);
		}

		if (mouseScroll < 0 && camera.fieldOfView < maxZoom) { //out
			camera.fieldOfView += Mathf.Lerp( camera.fieldOfView, -mouseScroll, Time.deltaTime);//Mathf.Max(camera.fieldOfView-mouseScroll*zoomSpeed, maxZoom);
			//transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(-2, 0, 0), 5f);
		}
	}
}

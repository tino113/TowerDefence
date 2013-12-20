using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float zoomSpeed = 5f;
	private float minZoom = 40;
	private float maxZoom = 100;

	//private float sensitivityDistance = 7.5f;

	private float moveSpeed = 5f;
	private float damping = 0.02f;
	private float cameraTargetField;

	private float horizontalMove = 0f;
	private float verticalMove = 0f;

	void Start () {
		cameraTargetField = camera.fieldOfView;
	}

	void Update () {
		horizontalMove += Input.GetAxis("Horizontal") * moveSpeed;
		verticalMove += Input.GetAxis("Vertical") * moveSpeed;
		float mouseScroll = (Input.GetAxis ("Mouse ScrollWheel")*10) * zoomSpeed;

		float _x = Mathf.Lerp (transform.position.x, horizontalMove, Time.deltaTime * damping);
		float _z = Mathf.Lerp (transform.position.z, verticalMove, Time.deltaTime * damping);

		// zoom in
		if (mouseScroll > 0 && cameraTargetField >= minZoom) {
			cameraTargetField += mouseScroll;
			//if (cameraTargetField > minZoom) {
			//	transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(2, 0, 0), 5f);
			//}

		// zoom out
		} else if (mouseScroll < 0 && cameraTargetField <= maxZoom) {
			cameraTargetField += mouseScroll;
			//if (cameraTargetField < maxZoom) {
			//	transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(-2, 0, 0), 5f);
			//}
		}

		transform.position = new Vector3 (_x, 7, _z);
		cameraTargetField = Mathf.Clamp (cameraTargetField, minZoom, maxZoom);
		camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, cameraTargetField, Time.deltaTime); 
	}
}

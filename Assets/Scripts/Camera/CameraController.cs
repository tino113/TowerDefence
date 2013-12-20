using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float zoomSpeed = 5f;
	private float zoomDamping = 6f;
	
	private float zoom = 40f;

	private float minHeight = 5f;
	private float maxHeight = 25f;
	private float minFoV = 40f;
	private float maxFoV = 60f;
	private float minRotate = 7f;
	private float maxRotate = 80f;

	private float moveSpeed = 1f;
	private float horizontalMove = 0f;
	private float verticalMove = 0f;
	private float moveDamping = 20f;

	void Start(){
		transform.localRotation = Quaternion.Euler ((((maxRotate - minRotate) / 100) * zoom) + minRotate, 0, 0);
	}

	void Update () {
		UpdateFromInput ();
		
		UpdateCamera (
			MoveLerp (transform.position.x, horizontalMove),
		    ZoomLerp (transform.position.y, minHeight, maxHeight),
		    MoveLerp (transform.position.z, verticalMove),
		    ZoomLerp (transform.localRotation.eulerAngles.x, minRotate, maxRotate),
		    ZoomLerp (camera.fieldOfView, minFoV, maxFoV)
		);
	}
	
	private float MoveLerp(float from, float to) {
		return Mathf.Lerp (from, to, Time.deltaTime * moveDamping);
	}
	
	private float ZoomLerp(float from, float min, float max) {
		float to = (((max - min) / 100) * zoom) + min;
		return Mathf.Lerp (from, to, Time.deltaTime * zoomDamping);
	}

	private void UpdateCamera(float x, float y, float z, float rotate, float fieldOfView) {
		transform.localRotation = Quaternion.Euler(rotate, 0, 0);
		transform.position = new Vector3 (x, y, z);
		camera.fieldOfView = fieldOfView;
	}

	private void UpdateFromInput(){
		horizontalMove += Input.GetAxis("Horizontal") * moveSpeed;
		verticalMove += Input.GetAxis("Vertical") * moveSpeed;
		zoom += Input.GetAxis ("Mouse ScrollWheel") * 40f;
		zoom = Mathf.Clamp (zoom, 0, 100);
	}
}

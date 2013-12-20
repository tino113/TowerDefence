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

		horizontalMove += Input.GetAxis("Horizontal") * moveSpeed;
		verticalMove += Input.GetAxis("Vertical") * moveSpeed;

		float _x = Mathf.Lerp (transform.position.x, horizontalMove, Time.deltaTime * moveDamping);
		float _z = Mathf.Lerp (transform.position.z, verticalMove, Time.deltaTime * moveDamping);


		zoom += Input.GetAxis ("Mouse ScrollWheel") * 40f;
		zoom = Mathf.Clamp (zoom, 0, 100);

		float targetHeight = (((maxHeight - minHeight) / 100) * zoom) + minHeight;
		float _y = Mathf.Lerp (transform.position.y, targetHeight, Time.deltaTime * zoomDamping);
		float FoVTarget = (((maxFoV - minFoV) / 100) * zoom) + minFoV;
		float _fov = Mathf.Lerp (camera.fieldOfView, FoVTarget, Time.deltaTime * zoomDamping);

		float rotationTarget = (((maxRotate - minRotate) / 100) * zoom) + minRotate;
		float _rotate = Mathf.Lerp (transform.localRotation.eulerAngles.x, rotationTarget, Time.deltaTime * zoomDamping);
		transform.localRotation = Quaternion.Euler(_rotate, 0, 0);

		transform.position = new Vector3 (_x, _y, _z);
		camera.fieldOfView = _fov;
	}
}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float zoomSpeed = 5f;
	private float zoomDamping = 6f;

	private float moveSpeed = 1f;
	private float moveDamping = 20f;

	private float minY = 5f;
	private float maxY = 25f;
	private float minFoV = 40f;
	private float maxFoV = 60f;
	private float minR = 7f;
	private float maxRs = 80f;

	private float zoom;
	private float targetX;
	private float targetY;
	private float targetZ;
	private float targetR;
	private float targetFoV;

	void Start(){
		zoom      = 30f;
		targetX   = 0f;
		targetY   = ZoomCalc(minY, maxY);
		targetZ   = -12f;
		targetR   = ZoomCalc(minR, maxRs);
		targetFoV = ZoomCalc(minFoV, maxFoV);
		UpdateCamera ();
	}

	void Update () {
		UpdateInput ();
		targetX   = MoveLerp (transform.position.x, targetX);
		targetY   = ZoomLerp (transform.position.y, minY, maxY);
		targetZ   = MoveLerp (transform.position.z, targetZ);
		targetR   = ZoomLerp (transform.localRotation.eulerAngles.x, minR, maxRs);
		targetFoV = ZoomLerp (camera.fieldOfView, minFoV, maxFoV);
		UpdateCamera ();
	}

	private float MoveLerp(float from, float to) {
		return Mathf.Lerp (from, to, Time.deltaTime * moveDamping);
	}

	private float ZoomLerp(float from, float min, float max) {
		return Mathf.Lerp (from, ZoomCalc(min, max), Time.deltaTime * zoomDamping);
	}

	private float ZoomCalc(float min, float max) {
		return (((max - min) / 100) * (100 - zoom)) + min;
	}

	private void UpdateCamera() {
		transform.localRotation = Quaternion.Euler(targetR, 0, 0);
		transform.position = new Vector3 (targetX, targetY, targetZ);
		camera.fieldOfView = targetFoV;
	}

	private void UpdateInput(){
		targetX += Input.GetAxis("Horizontal") * moveSpeed;
		targetZ += Input.GetAxis("Vertical") * moveSpeed;
		zoom += Input.GetAxis ("Mouse ScrollWheel") * 40f;
		zoom = Mathf.Clamp (zoom, 0, 100);
	}
}

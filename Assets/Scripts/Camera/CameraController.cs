using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float startX;
	public float startZ;

	private float zoomSpeed = 5f;
	private float zoomDamping = 6f;

	private float moveSpeed = 2f;
	private float moveDamping = 20f;

	private float minY = 5f;
	private float maxY = 50f;
	private float minFoV = 40f;
	private float maxFoV = 60f;
	private float minR = 12f;
	private float maxR = 80f;

	private float zoom;
	private float targetX;
	private float targetY;
	private float targetZ;
	private float targetR;
	private float targetFoV;

	void Start(){
		zoom      = 30f;
		targetX   = startX;
		targetY   = ZoomCalc(minY, maxY);
		targetZ   = startZ;
		targetR   = ZoomCalc(minR, maxR);
		targetFoV = ZoomCalc(minFoV, maxFoV);
		UpdateCamera ();
	}

	void Update () {
		UpdateInput ();
		targetX   = Lerp (transform.position.x, targetX, moveDamping);
		targetY   = Lerp (transform.position.y, ZoomCalc(minY, maxY), zoomDamping);
		targetZ   = Lerp (transform.position.z, targetZ, moveDamping);
		targetR   = Lerp (transform.localRotation.eulerAngles.x, ZoomCalc(minR, maxR), zoomDamping);
		targetFoV = Lerp (camera.fieldOfView, ZoomCalc(minFoV, maxFoV), zoomDamping);
		UpdateCamera ();
	}

	private float Lerp (float from, float to, float damping) {
		return Mathf.Lerp (from, to, Time.deltaTime * damping);
	}

	private float ZoomCalc (float min, float max) {
		return (((max - min) / 100) * (100 - zoom)) + min;
	}

	private void UpdateCamera() {
		transform.localRotation = Quaternion.Euler(targetR, 0, 0);
		transform.position = new Vector3 (targetX, targetY, targetZ);
		camera.fieldOfView = targetFoV;
	}

	private void UpdateInput(){
		targetX += Input.GetAxis("Horizontal") * ZoomCalc(moveSpeed/2, moveSpeed);
		targetZ += Input.GetAxis("Vertical") * ZoomCalc(moveSpeed/2, moveSpeed);
		zoom += Input.GetAxis ("Mouse ScrollWheel") * 40f;
		zoom = Mathf.Clamp (zoom, 0, 100);
	}
}

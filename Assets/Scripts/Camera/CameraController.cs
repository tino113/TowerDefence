using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float startX;
	public float startZ;

	public float zoomSpeed = 40f;
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
	private Vector3 targetMouse;

	public void Start () {
		zoom      = 30f;
		targetX   = startX;
		targetY   = FactorZoom(minY, maxY);
		targetZ   = startZ;
		targetR   = FactorZoom(minR, maxR);
		targetFoV = FactorZoom(minFoV, maxFoV);
		UpdateCamera ();
	}

	public void Update () {
		targetX += Input.GetAxis("Horizontal") * FactorZoom(moveSpeed/2, moveSpeed);
		targetZ += Input.GetAxis("Vertical") * FactorZoom(moveSpeed/2, moveSpeed);

		targetX   = Lerp (transform.position.x, targetX, moveDamping);
		targetY   = Lerp (transform.position.y, FactorZoom(minY, maxY), zoomDamping);
		targetZ   = Lerp (transform.position.z, targetZ, moveDamping);
		targetR   = Lerp (transform.localRotation.eulerAngles.x, FactorZoom(minR, maxR), zoomDamping);
		targetFoV = Lerp (camera.fieldOfView, FactorZoom(minFoV, maxFoV), zoomDamping);

		float scrollAmount = Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		if (scrollAmount != 0) {
			if (scrollAmount > 0) { // move towards point only when zooming in, not out
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitData;
				bool hit = Physics.Raycast (ray.origin, ray.direction, out hitData);
				targetMouse = hit ? hitData.point : targetMouse;

				targetX = Lerp(targetX, targetMouse.x, moveDamping);
				targetZ = Lerp(targetZ, targetMouse.z, moveDamping);
			}

			zoom += scrollAmount;
			zoom = Mathf.Clamp (zoom, 0, 100);
		}

		UpdateCamera ();
	}

	private float Lerp (float from, float to, float damping) {
		return Mathf.Lerp (from, to, Time.deltaTime * damping);
	}

	private float FactorZoom (float min, float max) {
		return (((max - min) / 100) * (100 - zoom)) + min;
	}

	private void UpdateCamera () {
		transform.localRotation = Quaternion.Euler(targetR, 0, 0);
		transform.position = new Vector3 (targetX, targetY, targetZ);
		camera.fieldOfView = targetFoV;
	}
}

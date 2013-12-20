using UnityEngine;
using System.Collections;

public class Laser : Actor {

	public Color lineColor;
	public GameObject barrelEnd;
	public GameObject target;

	public Color startColour = new Color(1f, 0f, 0.2f, 0.5f);
	public Color endColour = new Color(1f, 0f, 0f, 0.5f);

	public float lastFiredAt = 0.0f;

	public LineRenderer lineRenderer = new LineRenderer();

	// Use this for initialization
	public void Start () {
		lineRenderer = (LineRenderer)this.gameObject.AddComponent("LineRenderer");
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.SetColors (startColour, endColour);
		lineRenderer.SetWidth(0.03f,0.02f);
		lineRenderer.SetVertexCount(2);
		lineRenderer.enabled = false;

		lastFiredAt = Time.time;
	}

	public void fire () {
		for(int i = 0; i < 2; i++) {
			Vector3 pos = Vector3.Lerp(barrelEnd.transform.position , target.transform.position, i);
			lineRenderer.SetPosition(i, pos);
		}
		lineRenderer.enabled = true;
	}

	public void fireAt (GameObject at) {
		target = at;
		fire ();
	}

	public void fireFromTo (GameObject from, GameObject to) {
		target = to;
		barrelEnd = from;
		fire ();
	}

	public void fireFrom (Vector3 from, Vector3 direction) {
		RaycastHit hitData;
		bool hit = Physics.Raycast (from, direction, out hitData);
		lineRenderer.SetPosition(0, from);
		Vector3 linePos = hit ? hitData.point : from + direction*99999999.9f;
		lineRenderer.SetPosition(1, linePos);
		lineRenderer.enabled = true;
	}

	public bool fireFromAndTest (Vector3 from, Vector3 direction, GameObject target ) {
		RaycastHit hitData;
		bool hit = Physics.Raycast (from, direction, out hitData);
		lineRenderer.SetPosition (0, from);
		Vector3 linePos = hit ? hitData.point : from + direction*99999999.9f;
		lineRenderer.SetPosition(1, linePos);

		if (lastFiredAt == 0.0f || Time.time - (lastFiredAt + rateOfFire) >= pulseLength) {
			lineRenderer.enabled = true;
			lastFiredAt = Time.time;
		} else if ( Time.time - lastFiredAt >= pulseLength) {
			fireEnd();
		}

		return hit ? hitData.collider.gameObject == target : false ;
	}

	public void fireEnd (){
		lineRenderer.enabled = false;
	}
}

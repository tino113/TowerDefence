using UnityEngine;
using System.Collections;

public class Laser : Actor {

	public Color lineColor;
	public GameObject barrelEnd;
	public GameObject target;

	public Color startColour;
	public Color endColour;

	public float lastFiredAt = 0.0f;

	public LineRenderer lineRenderer = new LineRenderer();

	void Awake () {
	}

	// Use this for initialization
	void Start () {

		startColour.r = 1; startColour.g = 0; startColour.b = 0; startColour.a = 0.5f;
		endColour.r = 1; endColour.g = 0; endColour.b = 0.2f; endColour.a = 0.5f;

		lineRenderer = (LineRenderer)this.gameObject.AddComponent("LineRenderer");
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.SetColors (startColour, endColour);
		lineRenderer.SetWidth(0.03f,0.02f);
		lineRenderer.SetVertexCount(2);

		lineRenderer.enabled = false;

		lastFiredAt = Time.time;

	}
	
	// Update is called once per frame
	void Update () {


			
	}

	public void fire () {
		//lineRenderer = (LineRenderer)GetComponent ("lineRenderer");
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
		if (hit)
			lineRenderer.SetPosition(1, hitData.point);
		else
			lineRenderer.SetPosition(1, from + direction*99999999.9f);

		lineRenderer.enabled = true;
	}

	public bool fireFromAndTest (Vector3 from, Vector3 direction, GameObject target ) {
		RaycastHit hitData;
		bool hit = Physics.Raycast (from, direction, out hitData);

		lineRenderer.SetPosition (0, from);
		if (hit)
			lineRenderer.SetPosition (1, hitData.point);
		else
			lineRenderer.SetPosition (1, from + direction * 99999999.9f);
		
		if (lastFiredAt == 0.0f || Time.time - (lastFiredAt + rateOfFire) >= pulseLength) {
			lineRenderer.enabled = true;
			lastFiredAt = Time.time;
		} else if ( Time.time - lastFiredAt >= pulseLength) {
			lineRenderer.enabled = false;
		}

		return hit ? hitData.collider.gameObject == target : false ;
	}

	public void fireEnd (){
		lineRenderer.enabled = false;
	}

}

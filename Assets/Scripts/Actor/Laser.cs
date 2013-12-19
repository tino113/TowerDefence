using UnityEngine;
using System.Collections;

public class Laser : Actor {

	public Color lineColor;
	public GameObject barrelEnd;
	public GameObject target;

	public Color startColour;
	public Color endColour;

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
		lineRenderer.SetWidth(0.02f,0.02f);
		lineRenderer.SetVertexCount(2);

		lineRenderer.enabled = false;

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

	public void fireAt (GameObject target) {
		//lineRenderer = (LineRenderer)GetComponent ("lineRenderer");
		for(int i = 0; i < 2; i++) {
			Vector3 pos = Vector3.Lerp(barrelEnd.transform.position , target.transform.position, i);
			lineRenderer.SetPosition(i, pos);
		}
		lineRenderer.enabled = true;
	}

	public void fireEnd (){
		lineRenderer.enabled = false;
	}

}

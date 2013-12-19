using UnityEngine;
using System.Collections;

public class Laser : Actor {

	public Color lineColor;
	public GameObject barrelEnd;
	public Actor target;

	public Color startColour;
	public Color endColour;

	public LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = (LineRenderer)this.gameObject.AddComponent("LineRenderer");
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.SetColors (startColour, endColour);
		lineRenderer.SetWidth(0.2f,0.2f);
		lineRenderer.SetVertexCount(2);
	}
	
	// Update is called once per frame
	void Update () {


			
	}

	void Fire () {
		lineRenderer = (LineRenderer)GetComponent ("lineRenderer");
		for(int i = 0; i < 2; i++) {
			Vector3 pos = Vector3.Lerp(barrelEnd.transform.position , target.transform.position, i/2.0f);
			lineRenderer.SetPosition(i, pos);
		}
		target.health -= firePower;
	}

}

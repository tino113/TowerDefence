using UnityEngine;
using System.Collections;

public class LightSimulation : MonoBehaviour {

	private float x = 20f;
	private float y = 280f;
	private float z = 30f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		x += Time.deltaTime*2;
		y += Time.deltaTime/2;
		transform.localRotation = Quaternion.Euler(x, y, z);
	}
}

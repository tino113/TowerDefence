using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour {

	// common attributes for all Actors

	public float health = 100.0f;
	public float firePower = 0.2f;
	public float rateOfFire = 0.2f;
	public float targetDistance = 3.0f;
	//public enum actorType;

	public static List<GameObject> actorList;

	// initialise regardless of script being loaded
	void Awake () {

		if (actorList == null) //only initialise if not already done so.
			actorList = new List<GameObject>();

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		// check to see if health is below 0;
		if (health <= 0) {
			// TODO: play some kind of death animation
			// once the animationis finished then:
			Debug.Log(name + " I'm Dead!");
			Destroy(this.gameObject);
		}
	}
}

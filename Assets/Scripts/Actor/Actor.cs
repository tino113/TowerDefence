using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour {

	public float health = 100.0f;
	public float firePower = 1.0f;
	public float rateOfFire = 0.2f;
	public float pulseLength = 0.8f;
	public float targetDistance = 3.0f;
	//public enum actorType;

	public static List<GameObject> actorList;

	// initialise regardless of script being loaded
	public void Awake () {
		if (actorList == null) {
			actorList = new List<GameObject>();
		}
	}

	public void checkHealth () {
		if (health <= 0) {
			// TODO: play some kind of death animation once the animation is finished
			actorList.Remove(this.gameObject);
			Destroy(this.gameObject);
		}
	}

	protected void AddTagRecursive (Transform trans, string tag) {
		trans.gameObject.tag = tag;
		if (trans.childCount > 0) {
			foreach (Transform t in trans) {
				AddTagRecursive(t, tag);
			}
		}
	}

	public GameObject FindInChildren(string name) {
		return (from x in this.GetComponentsInChildren<Transform>()
				where x.gameObject.name == name
				select x.gameObject).First();
	}
}

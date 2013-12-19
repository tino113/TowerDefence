using UnityEngine;
using System.Collections;

public class Tower : Static {

	public Laser laser = new Laser();
	
	// common attributes for all Towers

	void Awake () {
		laser = (Laser)this.gameObject.AddComponent ("Laser");
	}

	// Use this for initialization
	void Start () {
		//laser = new Laser();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



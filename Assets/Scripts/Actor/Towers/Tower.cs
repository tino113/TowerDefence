using UnityEngine;
using System.Collections;

public class Tower : Static {

	public Laser laser = new Laser();

	public void Awake () {
		laser = (Laser)this.gameObject.AddComponent ("Laser");
	}
}



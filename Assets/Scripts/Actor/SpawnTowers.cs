using UnityEngine;
using System.Collections;

public class SpawnTowers : Actor {
	
	public GameObject towerType;
	public Vector3 targetPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown ()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		Physics.Raycast(ray, out hit);
		
		if(hit.collider.gameObject == gameObject)
		{
			targetPos = hit.point;

			// create a new tower
			GameObject instTower = (GameObject)Instantiate(towerType,targetPos, Quaternion.identity);
			instTower.AddComponent("Tower");

			instTower.tag = "friendly";
			actorList.Add (instTower);


			foreach (Transform child in instTower.transform){
				child.tag = "friendly";
				foreach (Transform child2 in child){
					child2.tag = "friendly";
					foreach (Transform child3 in child2){
						child3.tag = "friendly";
						if (child3.name == "Turret_Horiz"){
							child3.gameObject.AddComponent("RotateHoriz");
							foreach (Transform child4 in child3){
								child4.tag = "friendly";
								if (child4.name == "Turret_Vertical"){
									child4.gameObject.AddComponent("VerticalRotate");
								}
							}
						}
					}
				}
			}

		}
	}
}




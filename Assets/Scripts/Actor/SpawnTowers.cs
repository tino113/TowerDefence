using UnityEngine;
using System.Collections;

public class SpawnTowers : Actor {

	public GameObject towerType;
	public Vector3 targetPos;

	public void OnMouseDown () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);

		if (hit.collider.gameObject == gameObject) {
			targetPos = hit.point;

			GameObject instTower = (GameObject) Instantiate(towerType,targetPos, Quaternion.identity);
			instTower.AddComponent("Tower");
			instTower.tag = "friendly";
			AddTagRecursive(instTower.transform, "friendly");
			actorList.Add (instTower);

			foreach (Transform child in instTower.transform){
				foreach (Transform child2 in child){
					foreach (Transform child3 in child2){
						if (child3.name == "Turret_Horiz"){
							child3.gameObject.AddComponent("RotateHoriz");
							foreach (Transform child4 in child3){
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

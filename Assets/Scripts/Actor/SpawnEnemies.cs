using UnityEngine;
using System.Collections;

public class SpawnEnemies : Actor {

	public GameObject ground;
	public GameObject enemyType;
	public int maxNumEnemies = 50;
	[Range (0,10)] public float numSeconds = 0.2f;
	[Range (0,0.5f)] public float bias = 0.015f;

	public void Update () {
		if (Time.time % numSeconds <= bias && actorList.Count < maxNumEnemies)  {
			Vector3 randomPoint = new Vector3 (Random.Range (-5.0f, 5.0f), 0.0f, Random.Range (-5.0f, 5.0f));
			randomPoint = Vector3.Scale(randomPoint, ground.transform.localScale);
			GameObject instEnemy = (GameObject)Instantiate (enemyType, randomPoint, Quaternion.LookRotation(-randomPoint));
			instEnemy.AddComponent("BasicEnemy");
			instEnemy.AddComponent("BoxCollider"); // for raycast hit
			instEnemy.tag = "enemy";
			actorList.Add(instEnemy);
		}
	}
}

using UnityEngine;
using System.Collections;

public class SpawnEnemies : Actor {

	public GameObject ground;
	[Range (0,10)] public float numSeconds = 0.2f;
	[Range (0,0.5f)] public float bias = 0.015f;
	public int maxNumEnemies = 50;

	public GameObject enemyType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//approx every nth second
		if (Time.time % numSeconds <= bias && actorList.Count < maxNumEnemies) 
		{
			Vector3 randomPoint = new Vector3 (Random.Range (-5.0f, 5.0f), 0.0f, Random.Range (-5.0f, 5.0f));
			randomPoint = Vector3.Scale(randomPoint, ground.transform.localScale);
			GameObject instEnemy = (GameObject)Instantiate (enemyType, randomPoint, Quaternion.LookRotation(-randomPoint));
			instEnemy.AddComponent("BasicEnemy");

			instEnemy.tag = "enemy";
			actorList.Add(instEnemy);

		}
	}
}

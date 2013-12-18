using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

	public GameObject ground;
	[Range (0,10)] public float numSeconds = 0.2f;
	[Range (0,0.5f)] public float bias = 0.015f;
	public int maxNumEnemies = 50;
	public GameObject enemy;

	public static List<GameObject> enemyList;

	// Use this for initialization
	void Start () {

		enemyList = new List<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//approx every nth second
		if (Time.time % numSeconds <= bias && enemyList.Count < maxNumEnemies) 
		{
			Vector3 randomPoint = new Vector3 (Random.Range (-5.0f, 5.0f), 0.0f, Random.Range (-5.0f, 5.0f));
			randomPoint = Vector3.Scale(randomPoint, ground.transform.localScale);
			Vector3 origin = new Vector3 (0.0f, 0.0f, 0.0f);
			GameObject instEnemy = (GameObject)Instantiate (enemy, randomPoint, Quaternion.LookRotation(randomPoint-origin));
			Component movepos = instEnemy.AddComponent("BasicEnemy");
			//movepos.movementSpeed = Random.Range( 0.2f, 2.0f);
			//instEnemy.tag = "Enemy";

			enemyList.Add(instEnemy);
			//Debug.Log(enemyList.Count);
		}
	}
}

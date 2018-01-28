using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	[SerializeField]
	private float seconds;
	[SerializeField]
	private GameObject enemy;

	private float lastSpawnTime = 0;
	private bool canSpawn = false;

	// Use this for initialization
	void Start () {
		canSpawn = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canSpawn) {
			GenerateEntity ();
			lastSpawnTime = Time.realtimeSinceStartup;
			canSpawn = false;
		} else {
			if (Time.realtimeSinceStartup - lastSpawnTime >= seconds) {
				canSpawn = true;
			} 
		}
	}

	private void GenerateEntity() {
		
	}
}

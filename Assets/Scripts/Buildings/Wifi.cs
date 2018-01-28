using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wifi : TowerBlueprint {

	// Use this for initialization
	void Start () {
		this.cost = 500;
		this.prefab = this.gameObject;
		this.health = this.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

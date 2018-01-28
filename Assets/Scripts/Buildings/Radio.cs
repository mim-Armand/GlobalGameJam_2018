using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Entity {

	// Use this for initialization
	void Start () {
		health = maxHealth;
		this.faction = Affiliation.PLAYER;
		this.SetupHealthBar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

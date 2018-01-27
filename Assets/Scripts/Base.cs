using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Entity {

	// Use this for initialization
	void Start () {
		health = maxHealth;
		this.SetupHealthBar ();
	}
    
	// Update is called once per frame
	void Update () {
		
	}
}

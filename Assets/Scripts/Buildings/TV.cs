﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Entity {
	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private float damage;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		this.faction = Affiliation.PLAYER;
		this.SetupHealthBar ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.attackTimer <= 0) {
			//make sure the attack was successful
			AttackCycle (collider.gameObject);
		}
	}

	private void AttackCycle(GameObject obj) {
		Entity entity = obj.GetComponent<Entity> ();
		if (entity != null && entity.GetAffiliation () != this.faction) {
			attackTimer = attackDelaySeconds;
			Attacks.AoeAttack (projectile, this.transform.GetChild(0).gameObject, obj, damage);
		}
	}
}

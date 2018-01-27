using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : Entity {
	private GameObject enemyBase;

	// Use this for initialization
	void Start () {
		enemyBase = GameObject.FindWithTag ("Base");
		this.faction = Affiliation.COMPUTER;
	}

	protected override void Move ()
	{
		if (enemyBase != null && this.transform.position != enemyBase.transform.position) {
			canMove = true;
			this.transform.position = Vector2.MoveTowards (this.transform.position, enemyBase.transform.position, movementSpeed);
		} else {
			canMove = false;
		}
	}

	protected override void Die() {
		Debug.Log ("DEAD");
		GameObject.Destroy (this.gameObject);
	}

	protected override void Attack() {
	}
}

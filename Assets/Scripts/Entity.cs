using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the base clase which is extended by any object that has health
 */
public class Entity : MonoBehaviour {
	[SerializeField]
	protected float maxHealth;
	[SerializeField]
	protected float movementSpeed;
	[SerializeField]
	protected bool canAttack;
	[SerializeField]
	protected bool canMove;
	[SerializeField]
	protected Affiliation faction;

	protected float health = 0;

	void Update() {
		if (canMove)
			Move();

		if (canAttack)
			Attack();

		if (health <= 0)
			Die();
	}

	void OnCollisionEnter(Collision collision) {
		// Need to stub out functions for when something gets hit by a projectile. 
	}

	virtual protected void Die() {
		Debug.Log ("DEAD");
		GameObject.Destroy (this.gameObject);
	}

	virtual protected void Attack() {
	}

	virtual protected void Move() {
	}

	// This gets the normalized health value for fill of the healthbar
	protected float GetHealthNormalized() {
		return health / maxHealth;
	}
}

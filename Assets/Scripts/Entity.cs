using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the base clase which is extended by any object that has health
 */
public class Entity : MonoBehaviour {
	[SerializeField]
	protected float health;
	[SerializeField]
	protected float movementSpeed;
	[SerializeField]
	protected bool canAttack;
	[SerializeField]
	protected bool canMove;
	[SerializeField]
	protected Affiliation faction;

	virtual protected void Die() {
		Debug.Log ("DEAD");
		GameObject.Destroy (this.gameObject);
	}

	virtual protected void Attack() {
	}

	virtual protected void Move() {
	}

	void Update() {
		if (canMove)
			Move();

		if (canAttack)
			Attack();

		if (health <= 0)
			Die();
	}
}

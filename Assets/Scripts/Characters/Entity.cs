﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
	protected bool canMove;
	[SerializeField]
	protected Affiliation faction;
	[SerializeField]
	protected GameObject healthBar;
	[SerializeField]
	private float healthBarHeight;
	[SerializeField]
	private AudioSource deathSounds;
	[SerializeField]
	protected float attackDelaySeconds;
	[SerializeField]
	protected bool canAttack;

    protected float health = 100;
	protected Navigator nav;
	protected Vector2 lastPoint;

	protected float attackTimer = 0.0f;

	void FixedUpdate() {
		if (canMove) {
			Move ();
			SetProperRotation ();
			healthBar.transform.position = this.transform.position + new Vector3 (0f, healthBarHeight, -.01f);
		}
			
		if (canAttack && attackTimer > 0.0) {
			attackTimer -= Time.fixedDeltaTime;
			//Debug.Log (attackTimer + "Entity");
		} 

		if (health <= 0)
			Die();
	}

	void OnCollisionEnter(Collision collision) {
		// Need to stub out functions for when something gets hit by a projectile. 
	}

    public Affiliation GetAffiliation()
    {
        return faction;
    }

	public void SetNavigator(Navigator navigator) {
		this.nav = navigator;
	}

    public void TakeDamage (float damage)
    {
		Debug.Log(this.gameObject.name + "has launched TakeDamage with " + damage + " damage");
        health -= damage;
		healthBar.transform.GetChild(0).transform.GetChild(0).GetComponent<Image> ().fillAmount = GetHealthNormalized ();
    }
	virtual protected void Die() {
		this.canMove = false;
		Debug.Log ("DEAD");
		DoDeathSounds ();
	}

	// This is different from death and caused by when a unit reaches the player base
	virtual protected void Despawn() {
		Debug.Log ("Despawning");
		GameObject.Destroy (healthBar.gameObject);
		GameObject.Destroy (this.gameObject);
	}

	virtual protected void Attack(GameObject defender) {
	}

	virtual protected void Move() {
	}

	// This gets the normalized health value for fill of the healthbar
	protected float GetHealthNormalized() {
		return health / maxHealth;
	}

	protected void SetupHealthBar() {
		healthBar = GameObject.Instantiate (healthBar);
		healthBar.transform.position = this.transform.position + new Vector3 (0f, healthBarHeight, 0f);
		healthBar.transform.localScale = this.transform.localScale;
	}

	// this is used to flip around the sprite so the animations look correct
	private void SetProperRotation() {
		//it means we are going left 
		if (this.transform.position.x < lastPoint.x) {
			this.transform.rotation = new Quaternion (0f, 180f, 0f, 0f);
		} else {
			this.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}

		lastPoint = this.transform.position;
	}

	private void DoDeathSounds()
	{
		if (deathSounds != null) {
			deathSounds.Play ();
			Debug.Log ("printing death");
		}
		GameObject.Destroy (healthBar.gameObject);
		GameObject.Destroy (this.gameObject);
	}
}

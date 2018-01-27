using System.Collections;
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
	protected bool canAttack;
	[SerializeField]
	protected bool canMove;
	[SerializeField]
	protected Affiliation faction;
	[SerializeField]
	protected GameObject healthBar;

    protected float health = 100;
	protected Navigator nav;

	void FixedUpdate() {
		if (canMove) {
			Move ();
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
        Debug.Log("Entity has launched TakeDamage with " + damage + " damage");
        health -= damage;
		healthBar.GetComponentInChildren<Image> ().fillAmount = GetHealthNormalized ();
        Debug.Log(health);
    }
	virtual protected void Die() {
		Debug.Log ("DEAD");
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
		healthBar.transform.position = this.transform.position + new Vector3 (0f, .5f, 0f);
		healthBar.transform.SetParent (this.transform);
	}
}

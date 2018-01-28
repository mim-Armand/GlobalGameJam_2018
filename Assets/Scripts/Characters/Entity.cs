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
	[SerializeField]
	private float healthBarHeight;
	[SerializeField]
	private AudioSource deathSounds;

    protected float health = 100;
	protected Navigator nav;
	protected Vector2 lastPoint;

	void FixedUpdate() {
		if (canMove) {
			Move ();
			SetProperRotation ();
			healthBar.transform.position = this.transform.position + new Vector3 (0f, healthBarHeight, -.01f);
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
		healthBar.transform.GetChild(0).transform.GetChild(0).GetComponent<Image> ().fillAmount = GetHealthNormalized ();
        Debug.Log(health);
    }
	virtual protected void Die() {
		Debug.Log ("DEAD");
		StartCoroutine(DoDeathSounds()) ;
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

	private IEnumerator DoDeathSounds()
	{
		if(deathSounds != null)
			deathSounds.Play ();
		
		yield return new WaitForSeconds(3.0f);
		GameObject.Destroy (healthBar.gameObject);
		GameObject.Destroy (this.gameObject);
	}
}

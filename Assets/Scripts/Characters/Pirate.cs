using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : Entity {
    [SerializeField]
    private float damage;
	private GameObject enemyBase;
    private int count = 0;
	private GameObject enemyTarget;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		enemyBase = GameObject.FindWithTag ("Base");
		this.faction = Affiliation.COMPUTER;
		this.SetupHealthBar ();
	}

	void OnCollisionStay2D(Collision2D collision) {
		if (collision.gameObject.tag == "Base") {
			this.Attack (collision.gameObject);
			this.Despawn ();
		} else if (collision.gameObject.GetComponent<Entity> ().GetAffiliation () != this.faction && this.attackTimer  <= 0.0f) {
			this.Attack (collision.gameObject);
			this.attackTimer = this.attackDelaySeconds;
		}
	}


	void OnTriggerEnter2D(Collider2D collider) {
		Entity entity = collider.GetComponent<Entity> ();
		if (entity != null && entity.GetAffiliation () != this.faction && enemyTarget == null) {
			enemyTarget = collider.gameObject;
			attackTimer = attackDelaySeconds;
		}
	}


    protected override void Move ()
	{
		// choose between moving towards base and moving towards enemy target
		if (enemyBase != null && this.transform.position != enemyBase.transform.position && enemyTarget == null) {
			canMove = true;
			this.transform.position = Vector2.MoveTowards (this.transform.position, nav.Navigate (this.transform.position), movementSpeed);
		} else if (enemyTarget != null) {
			this.transform.position = Vector2.MoveTowards (this.transform.position, enemyTarget.transform.position, movementSpeed);
		} else {
			canMove = false;
		}
	}

	protected override void Attack(GameObject defender) {
		Attacks.MeleeAttack(defender, damage);
    }


}

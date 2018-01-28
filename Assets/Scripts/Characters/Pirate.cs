using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : Entity {
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float damage;
	private GameObject enemyBase;
    private int count = 0;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		enemyBase = GameObject.FindWithTag ("Base");
		this.faction = Affiliation.COMPUTER;
		this.SetupHealthBar ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Base") {
			this.Attack (collision.gameObject);
			this.Despawn ();
		}
	}


    protected override void Move ()
	{
		if (enemyBase != null && this.transform.position != enemyBase.transform.position) {
			canMove = true;
			this.transform.position = Vector2.MoveTowards (this.transform.position, nav.Navigate(this.transform.position), movementSpeed);
		} else {
			canMove = false;
		}
	}

	protected override void Attack(GameObject defender) {
		Attacks.MeleeAttack(defender, damage);
    }


}

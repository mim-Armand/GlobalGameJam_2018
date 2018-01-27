using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : Entity {
    [SerializeField]
    private GameObject projectile;
	private GameObject enemyBase;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		enemyBase = GameObject.FindWithTag ("Base");
		this.faction = Affiliation.COMPUTER;
	}

    void OnCollisionEnter2D(Collision2D hitbox)
    {
        Debug.Log("this worked");
        this.Attack(hitbox.gameObject);
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

	protected override void Attack(GameObject defender) {
        Attacks.ShootStart(projectile, this.gameObject, defender);
	}
}

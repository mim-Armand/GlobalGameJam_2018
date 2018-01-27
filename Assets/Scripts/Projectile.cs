﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private Transform projectileclass_heading;
    private float damage;
    protected Affiliation faction;

	// Use this for initialization
	void Start () {
		
	}

    public void SetFaction(Affiliation parentfaction)
    {
        faction = parentfaction;
        Debug.Log("Projectile has set its faction.");
    }

    public void SetMovementDirection(Transform attackclass_heading)
    {
        projectileclass_heading = attackclass_heading;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (projectileclass_heading != null && projectileclass_heading.position != this.transform.position)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, projectileclass_heading.position, .02f);
        }



    }
    public void SetDamage(float input_damage)
    {
        damage = input_damage;
    }

    void OnCollisionEnter2D(Collision2D hitbox)
    {
        Debug.Log("Projectile has launched OnCollisionEnter2D " + hitbox.gameObject.name);
        if (hitbox.gameObject.GetComponent<Entity>().GetAffiliation() != this.faction)
            {
                hitbox.gameObject.GetComponent<Entity>().TakeDamage(damage);
            Debug.Log("Projectile has dealt damage in OnCollisionEnter2D");
            }
        GameObject.Destroy(this.gameObject);
    }
}

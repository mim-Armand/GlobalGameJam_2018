using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour {
	[SerializeField]
	private float aliveTime;
	private float damage;
	private Affiliation faction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (aliveTime > 0.0) {
			aliveTime -= Time.fixedDeltaTime;
		} else {
			GameObject.Destroy (this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		Entity entity = collider.GetComponent<Entity> ();
		if (entity != null && entity.GetAffiliation () != this.faction) {
			entity.TakeDamage (damage);
		}
	}

	public void SetFaction(Affiliation parentfaction) {
		faction = parentfaction;
		Debug.Log("AOE has set its faction.");
	}

	public void SetDamage(float damage) {
		this.damage = damage;
	}
}

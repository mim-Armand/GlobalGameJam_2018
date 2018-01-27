using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private Transform projectileclass_heading;
    private float movementspeed_factor = .1f;

	// Use this for initialization
	void Start () {
		
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
            this.transform.LookAt(projectileclass_heading);
            this.transform.position = this.transform.position + new Vector3(0, .01f);
        }
     }
}

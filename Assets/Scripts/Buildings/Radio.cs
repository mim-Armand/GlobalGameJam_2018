using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public Transform target;
    [Header("Attributes")]
    public float range = 10f;
    public Transform partToRotate; //rotate the TV so that it would follow the enemy
    public string pirateTag = "Pirate";
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    [Header("Unity Setup Fields")]
    public GameObject RadiosignalPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //invoke the UpdateTarget method 2 times per second to confirm the target
    }


    void UpdateTarget()
    {
        GameObject[] pirates = GameObject.FindGameObjectsWithTag(pirateTag);
        //store the shortest distance to the enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPirate = null;
        foreach (GameObject pirate in pirates)
        {
            float distanceToPirate = Vector3.Distance(transform.position, pirate.transform.position); //return the distance in unity unit to be stored in the float
            //scan for the nearest pirate
            if (distanceToPirate < shortestDistance)
            {
                shortestDistance = distanceToPirate;
                nearestPirate = pirate;
            }
        }
        //check if nearest enemy isnt null 
        if (nearestPirate != null && shortestDistance <= range)
        {
            target = nearestPirate.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        //Lock onto the target
        //arrow that points to the direction of the pirate
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //rotate the TV to the direction of the pirate on the y axis only
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //bullet
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject RadioGO = (GameObject)Instantiate(RadiosignalPrefab, firePoint.position, firePoint.rotation);
        TVsignal radiosignal = RadioGO.GetComponent<TVsignal>();

        if (radiosignal != null)
        {
            radiosignal.Seek(target);
        }
    }
    private void OnDrawGizmosSelected() //show the attack range of the tower
    {
        Gizmos.color = Color.red; //the range has red color
        Gizmos.DrawWireSphere(transform.position, range); //show the range of the TV when hoevered over
    }
}

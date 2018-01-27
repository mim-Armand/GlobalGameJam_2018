using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attacks
{
    public static void ShootStart(GameObject projectile, GameObject attacker, GameObject defender)
    {
        projectile = GameObject.Instantiate(projectile, attacker.transform);
        Projectile projectilescript = projectile.GetComponent<Projectile>();
        if (projectilescript != null)
        {
            projectilescript.SetMovementDirection(defender.transform);
        }
    }
}

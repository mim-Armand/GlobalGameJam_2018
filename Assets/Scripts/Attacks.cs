using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attacks
{
    public static void ShootStart(GameObject projectile, GameObject attacker, GameObject defender, float damage)
    {
        projectile = GameObject.Instantiate(projectile);
        projectile.transform.position = Vector2.Lerp(attacker.transform.position, defender.transform.position, .3f);
        projectile.GetComponent<Projectile>().SetDamage(damage);
        Projectile projectilescript = projectile.GetComponent<Projectile>();
        if (projectilescript != null)
        {
            projectilescript.SetMovementDirection(defender.transform);
        }
        projectile.GetComponent<Projectile>().SetFaction(attacker.GetComponent<Entity>().GetAffiliation()); 
    }
}

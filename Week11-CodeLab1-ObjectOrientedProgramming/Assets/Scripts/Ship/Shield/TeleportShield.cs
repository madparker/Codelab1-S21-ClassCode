using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShield : BaseShield
{
    //take normal damage, but teleport to new location on X
    public override float AdjustDamage(float damage)
    {
        Vector2 currentPos = transform.position;
        currentPos.x = Random.Range(-5f, 5f);
        transform.position = currentPos;
        
        return damage;
    }
}

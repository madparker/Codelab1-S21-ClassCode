using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbShield : BaseShield
{
    public override float AdjustDamage(float damage)
    {
        return -damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleAttack : BaseAttack
{
    public override void SpawnBullet(Vector2 currentPos)
    {
        base.SpawnBullet(currentPos);
        currentPos.x += 0.5f;
        base.SpawnBullet(currentPos);
        currentPos.x -= 1f;
        base.SpawnBullet(currentPos);
    }
}

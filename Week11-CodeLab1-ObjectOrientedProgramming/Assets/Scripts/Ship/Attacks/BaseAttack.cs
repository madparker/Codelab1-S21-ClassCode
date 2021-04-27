using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public virtual void Attack()
    {
        Debug.Log("Attack!!!");

        GameObject bullet = Instantiate<GameObject>(bulletPrefab);

        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
        
        Vector2 currentPos = transform.position;
        currentPos.y += 1f;

        bullet.transform.position = currentPos;
    }
}

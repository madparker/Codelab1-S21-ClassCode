using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) //if the obstacle gets hit
    {
        if (other.gameObject.name.Contains("Player")) //if the player hit us
        {
            //Call "ResetPlayer" in the ASCIILevelLoader that we reference through
            //the GameManager Singleton
            GameManager.instance.GetComponent<ASCIILevelLoader>().ResetPlayer();
        }
    }
}

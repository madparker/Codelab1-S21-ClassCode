using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackADot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when the Mouse Button is down and you're over an object
    //using Unity collider
    void OnMouseDown()
    {
        Debug.Log("Clicked on Dot!!!");

        //move the dot to a new random location
        transform.position = 
            new Vector2(
                Random.Range(-6f, 6f),
                Random.Range(-4f, 4f));

        //increase the Score property in the GameManager Singleton by 1
        GameManager.instance.Score++;
    }
}

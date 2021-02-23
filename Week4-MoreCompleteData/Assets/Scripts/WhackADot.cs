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

    void OnMouseDown()
    {
        Debug.Log("Clicked on Dot!!!");

        transform.position = 
            new Vector2(
                Random.Range(-6f, 6f),
                Random.Range(-4f, 4f));

        GameManager.instance.Score++;
    }
}

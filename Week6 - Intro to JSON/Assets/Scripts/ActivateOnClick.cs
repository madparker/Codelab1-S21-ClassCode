using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    Rigidbody rigidbody; //var for rigidbody
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //get the rigidbody component
        rigidbody.isKinematic = true; //turn physics off of this rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() //when clicked on
    {
        rigidbody.isKinematic = false; //turn physics on
    }
}

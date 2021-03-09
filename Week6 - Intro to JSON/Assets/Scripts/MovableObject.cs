using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    string filePath; //path to save file
    
    // Start is called before the first frame update
    void Start()
    {
        //make the path to the save file based on the name of the gameObject
        filePath = Application.dataPath + "/" + name + ".json";

        if (File.Exists(filePath)) //if the file exists
        {
            string jsonStr = File.ReadAllText(filePath); //read in file

            //use JsonUtility to transform the file into a Vector3
            Vector3 savePosition = JsonUtility.FromJson<Vector3>(jsonStr);

            //set the position of the gameObject to the position in the file
            transform.position = savePosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag() //if the mouse is dragged on the gameObject
    {
        //set it's position to where ever it was dragged
        transform.position = GetMouseWorldPosition();
    }

    void OnApplicationQuit() //when the application is quit
    {
        //turn the transform.position into a JSON string with JsonUtility
        string jsonPosition = 
            JsonUtility.ToJson(transform.position, true);
        
        //print out the string to the console
        Debug.Log(jsonPosition);
        
        //write the JSON string to the filePath file
        File.WriteAllText(filePath, jsonPosition);
    }

    Vector3 GetMouseWorldPosition() //turn the screen position into a world position
    {
        //get the screen position of the mouse
        Vector3 mousePosition = Input.mousePosition;

        //set the z of the mouse based on the world positon of the gameObject
        mousePosition.z = 
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //return the transformed ScreenToWorldPoint of the mouse, based on the gameObjects z
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}

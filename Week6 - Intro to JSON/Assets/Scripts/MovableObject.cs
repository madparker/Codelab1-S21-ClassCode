using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    string filePath;
    
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/" + name + ".json";

        if (File.Exists(filePath))
        {
            string jsonStr = File.ReadAllText(filePath);

            Vector3 savePosition = JsonUtility.FromJson<Vector3>(jsonStr);

            transform.position = savePosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    void OnApplicationQuit()
    {
        string jsonPosition = 
            JsonUtility.ToJson(transform.position, true);
        Debug.Log(jsonPosition);
        File.WriteAllText(filePath, jsonPosition);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = 
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}

using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    
    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    
    public string file_name;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        string current_file_path = //build path to the level file
            Application.dataPath + 
            "/Levels/" + 
            file_name;

        string[] fileLines = File.ReadAllLines(current_file_path);

        for (int y = 0; y < fileLines.Length; y++)
        {

            string lineText = fileLines[y];

            char[] characters = lineText.ToCharArray();

            for (int x = 0; x < characters.Length; x++)
            {
                char c = characters[x];

                GameObject newObj;

                switch (c)
                {
                    case 'p':
                        newObj = Instantiate<GameObject>(player);
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(obstacle);
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.position = 
                        new Vector3(x + xOffset, -y + yOffset, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    public GameObject goal;

    public GameObject currentPlayer;
    
    Vector2 startPos;
    
    public string file_name;

    public int currentLevel = 0;

    public int CurrentLevel
    {
        get { return currentLevel;}
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level");
        
        string current_file_path = //build path to the level file
            Application.dataPath + 
            "/Levels/" + 
            file_name.Replace(
                "Num", 
                currentLevel + "");

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
                        if (currentPlayer == null)
                            currentPlayer = newObj;
                        startPos = new Vector2(
                            x + xOffset, -y + yOffset);
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(obstacle);
                        break;
                    case '&':
                        newObj = Instantiate<GameObject>(goal);
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    if (!newObj.name.Contains("Player"))
                    {
                        newObj.transform.parent = level.transform;
                    }

                    newObj.transform.position = 
                        new Vector3(x + xOffset, -y + yOffset, 0);
                }
            }
        }
    }

    public void ResetPlayer()
    {
        currentPlayer.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

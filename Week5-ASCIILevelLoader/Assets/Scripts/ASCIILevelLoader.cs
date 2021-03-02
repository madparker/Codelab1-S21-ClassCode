using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    //offset vars for the level position
    public float xOffset;
    public float yOffset;
    
    //Prefabs for the gameObjects we want to add to our scene
    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject goal;

    //var for the current player
    public GameObject currentPlayer;
    
    //var for the start position
    Vector2 startPos;
    
    //name of the level file
    public string fileName;

    //current level var
    public int currentLevel = 0;

    //property wrapping currentLevel
    //when the level changes, we load that level
    public int CurrentLevel
    {
        get { return currentLevel;}
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    //empty game object that holds the level
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(); //call load level
    }

    //function that creates the level based on the ASCII Text File
    void LoadLevel()
    {
        Destroy(level); //destroy the current level
        level = new GameObject("Level"); //create a new level gameObject
        
        //build up a new level path based on the currentLevel
        string current_file_path = //build path to the level file
            Application.dataPath + 
            "/Levels/" + 
            fileName.Replace(
                "Num", 
                currentLevel + "");

        //pull the contents of the file into a string array
        //each line in the file becomes an item in the array
        string[] fileLines = File.ReadAllLines(current_file_path);
        
        //loop through each line
        for (int y = 0; y < fileLines.Length; y++)
        {
            //get the current line
            string lineText = fileLines[y];

            //split the line into a char array
            char[] characters = lineText.ToCharArray();

            //loop through each char
            for (int x = 0; x < characters.Length; x++)
            {
                //grab the current char
                char c = characters[x];

                //var for newObj
                GameObject newObj;

                switch (c) //switch statement for the car
                {
                    case 'p': //if char is a 'p'
                        //make a player gameObject
                        newObj = Instantiate<GameObject>(player);
                        if (currentPlayer == null) //if we don't have a currentPlayer
                            currentPlayer = newObj; //make this the currentPlayer
                        //save this position to startPos to use for reseting the player
                        startPos = new Vector2(
                            x + xOffset, -y + yOffset);
                        break;
                    case 'w': //if char is a 'w'
                        //make a wall
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '*': //if char is an '*'
                        //make an obstacle
                        newObj = Instantiate<GameObject>(obstacle);
                        break;
                    case '&': //if char is '&'
                        //make a goal
                        newObj = Instantiate<GameObject>(goal);
                        break;
                    default: //if the char is anything else
                        newObj = null;  //make newObj null
                        break;
                }

                if (newObj != null) //if newObj is not null
                {
                    //if newObj is not a player
                    if (!newObj.name.Contains("Player"))
                    {
                        //make the level gameObject it's parent
                        newObj.transform.parent = level.transform;
                    }

                    //whatever newObj is, set it's position based on the offsets
                    //and it's position in the file
                    newObj.transform.position = 
                        new Vector3(x + xOffset, -y + yOffset, 0);
                }
            }
        }
    }

    //function to reset the player
    public void ResetPlayer()
    {
        //return player to the startPos
        currentPlayer.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

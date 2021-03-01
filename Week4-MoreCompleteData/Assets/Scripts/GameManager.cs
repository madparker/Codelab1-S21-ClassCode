using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //var for length of a game
    public float gameTime = 10;

    //display for the game
    public Text displayText;
    
    //var to track time
    float timer = 0;
    
    //private scare var
    int score;

    //Score property, wraps score var
    public int Score
    {
        get { return score; }
        set
        {
            score = value; 
        }
    }

    //List of all the high scores
    List<int> highScores;
    
    //GameManager Singleton var
    public static GameManager instance;

    //flag for if you are in game mode
    bool isGame = true;

    //file to store high scores
    const string FILE_HIGH_SCORES = "/highScores.txt";
    
    //full path to high scores
    string FILE_PATH_HIGH_SCORE;
    
    void Awake()
    {
        if (instance == null) //if we don't have a singleton
        {
            instance = this; //make this the singleton
            DontDestroyOnLoad(gameObject); //don't destroy it on new scene load
        }
        else //otherwise
        {
            Destroy(gameObject); //destroy the gameObject
        }
    }

    // Start is called before the first frame update
    void Start() 
    {
        timer = 0; //set the timer to 0
        
        //create the full path to the high score file
        //using Application.dataPath, which will find
        //the correct location regardless of the platform
        //you are using
        FILE_PATH_HIGH_SCORE = Application.dataPath + FILE_HIGH_SCORES;
    }

    // Update is called once per frame
    void Update()
    {
        //increase the timer for this frame
        timer += Time.deltaTime;

        if (!isGame) //if we're not in the game, display high scores
        {
            //make the highScoreString
            string highScoreString = "High Scores\n\n";

            //for loop for all the high scores
            for (var i = 0; i < highScores.Count; i++)
            {
                //add each high score to the string
                highScoreString += highScores[i] + "\n";
            }

            //set the displayText to the string we just built
            displayText.text = highScoreString;
        }
        else //if we are in the game, display timer
        {
            //set the displayText to the timers
            displayText.text = "Time: " + (int) (gameTime - timer + 1);
        }

        //Debug.Log("Time: " + timer);

        if (gameTime < timer && isGame) //Time is up and in the game scene
        {
            //go to gameOver scene
            SceneManager.LoadScene(1);
            isGame = false; //flip the flag to show were not playing the game
            UpdateHighScores(); //call update high scores
        }
    }

    void UpdateHighScores()
    {
        if (highScores == null) //if we don't have the high scores yet
        {
            highScores = new List<int>();

            string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORE);

            string[] fileScores = fileContents.Split(',');
            
            print(fileScores.Length);

            for (var i = 0; i < fileScores.Length - 1; i++)
            {
                highScores.Add(Int32.Parse(fileScores[i]));
            }
        }

        for (var i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                break;
            }
        }

        string saveHighScoreString = "";

        for (var i = 0; i < highScores.Count; i++)
        {
            saveHighScoreString += highScores[i] + ",";
        }

        File.WriteAllText(FILE_PATH_HIGH_SCORE, saveHighScoreString);
    }
}

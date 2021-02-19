using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    private int score = 0;

    const string DIR_LOGS = "/Logs";
    const string FILE_SCORES = DIR_LOGS + "/highScore.txt";
    const string FILE_ALL_SCORES = DIR_LOGS + "/allScores.csv";
    string FILE_PATH_HIGH_SCORES;
    string FILE_PATH_ALL_SCORES;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;

            //Debug.Log("Someone set the Score!");
            if (score > HighScore)
            {
                HighScore = score;
            }

            string fileContents = "";
            if (File.Exists(FILE_PATH_ALL_SCORES))
            {
                fileContents = File.ReadAllText(FILE_PATH_ALL_SCORES);
            }

            fileContents += score + ",";
            File.WriteAllText(FILE_PATH_ALL_SCORES, fileContents);

        }
    }

    const string PREF_KEY_HIGH_SCORE = "HighScoreKey";
    int highScore = -1;

    public int HighScore
    {
        get
        {
            if (highScore < 0)
            {
                //highScore = PlayerPrefs.GetInt(PREF_KEY_HIGH_SCORE, 3);
                if (File.Exists(FILE_PATH_HIGH_SCORES))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORES);
                    highScore = Int32.Parse(fileContents);
                }
                else
                {
                    highScore = 3;
                }
            }

            return highScore;
        }
        set
        {
            highScore = value;
            Debug.Log("New High Score!!!");
            Debug.Log("File Path: " + FILE_PATH_HIGH_SCORES);
            //PlayerPrefs.SetInt(PREF_KEY_HIGH_SCORE, highScore);

            if (!File.Exists(FILE_PATH_HIGH_SCORES))
            {
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
                //File.Create(FILE_PATH_HIGH_SCORES);
            }

            File.WriteAllText(FILE_PATH_HIGH_SCORES, highScore + "");
        }
    }

    int targetScore = 3;

    int currentLevel = 0;

    public Text text;  //TextMesh Component to tell you the time and the score
    
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH_HIGH_SCORES = Application.dataPath + FILE_SCORES;
        FILE_PATH_ALL_SCORES  = Application.dataPath + FILE_ALL_SCORES;
    }

    // Update is called once per frame
    void Update()
    {

        //update the text with the score and level
        text.text = "Level:" + currentLevel + 
                    "\nScore: " + score + " Target: " + targetScore +
                    "\nHigh Score: " + HighScore;
        
        if (score == targetScore)  //if the current score == the targetScore
        {
            currentLevel++; //increase the level number
            SceneManager.LoadScene(currentLevel); //go to the next level
            targetScore += targetScore + targetScore/2; //update target score
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTime = 10;

    public Text timerText;
    
    float timer = 0;
    
    int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value; 
        }
    }

    List<int> highScores;
    
    public static GameManager instance;

    bool isGame = true;

    const string FILE_HIGH_SCORES = "/highScores.txt";
    string FILE_PATH_HIGH_SCORE;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        FILE_PATH_HIGH_SCORE = Application.dataPath + FILE_HIGH_SCORES;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!isGame) //if we're not in the game, display high scores
        {
            string highScoreString = "High Scores\n\n";

            for (var i = 0; i < highScores.Count; i++)
            {
                highScoreString += highScores[i] + "\n";
            }

            timerText.text = highScoreString;
        }
        else //if we are in the game, display timer
        {
            timerText.text = "Time: " + (int) (gameTime - timer + 1);
        }

        //Debug.Log("Time: " + timer);

        if (gameTime < timer && isGame) //Time is up and in the game scene
        {
            SceneManager.LoadScene(1);
            isGame = false;
            UpdateHighScores();
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

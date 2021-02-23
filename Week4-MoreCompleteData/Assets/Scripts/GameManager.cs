using System.Collections;
using System.Collections.Generic;
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

        Debug.Log("Time: " + timer);

        if (gameTime < timer && isGame) //Time is up and in the game scene
        {
            SceneManager.LoadScene(1);
            isGame = false;
            UpdateHighScores();
        }
    }

    void UpdateHighScores()
    {
        if (highScores == null) //TODO populate with file IO
        {
            highScores = new List<int>();
            
            highScores.Add(2);
            highScores.Add(1);
        }

        for (var i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                break;
            }
        }
    }
}

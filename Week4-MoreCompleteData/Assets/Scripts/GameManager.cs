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

    public static GameManager instance;

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

        timerText.text = "Time: " + (int)(gameTime - timer + 1);
        
        Debug.Log("Time: " + timer);

        if (gameTime < timer) //Time is up
        {
            SceneManager.LoadScene(1);
        }
    }
}

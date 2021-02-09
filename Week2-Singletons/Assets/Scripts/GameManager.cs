using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    int targetScore = 3;

    int currentLevel = 0;

    public TextMesh text;
    
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level:" + currentLevel + " Score: " + score + " Target: " + targetScore;
        
        if (score == targetScore)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            targetScore += targetScore + targetScore/2;
        }
    }
}

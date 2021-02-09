using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    public int score = 0;

    int targetScore = 3;

    int currentLevel = 0;

    public TextMesh text;  //TextMesh Component to tell you the time and the score
    
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
    }

    // Update is called once per frame
    void Update()
    {
        //update the text with the score and level
        text.text = "Level:" + currentLevel + " Score: " + score + " Target: " + targetScore;
        
        if (score == targetScore)  //if the current score == the targetScore
        {
            currentLevel++; //increase the level number
            SceneManager.LoadScene(currentLevel); //go to the next level
            targetScore += targetScore + targetScore/2; //update target score
        }
    }
}

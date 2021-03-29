﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StackExample : MonoBehaviour
{
    private Stack<string> effects = new Stack<string>();

//    private Queue<float> amountToRemoveFromTimer = new Queue<float>();

    public Text display;

    private float timer = 0;
    private float timePerTurn = 5;

    private void Start()
    {
    }

    private void Update()
    {
        // If you press space, reload the scene.  This makes it easy to restart!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // If a move takes more than 5 seconds, continue.
        if (timer > timePerTurn) return;
        
        // Increase the timer.
        timer += Time.deltaTime;

        // If you press A, S, D, or F, push that move into the stack.
        if (Input.GetKeyDown(KeyCode.A))
        {
            effects.Push("RESOLVE: Abigail casts Firebolt.");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            effects.Push("RESOLVE: Sam casts Delay.");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            effects.Push("RESOLVE: Diana casts Portcullis.");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            effects.Push("RESOLVE: Frank casts Yam Sandwich.");
        }

        // If the time is up, say that time is up and show the effects.
        if (timer >= timePerTurn)
        {
            display.text = "Time is up!\n";

            ShowStackEffects();
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F2");
        }
    }

    private void ShowStackEffects()
    {
        // While there are effects in the stack, pop them out and show them.
        while (effects.Count > 0)
            display.text += "\n" + effects.Pop();
    }
}

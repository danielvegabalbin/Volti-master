using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBTN : MonoBehaviour
{

    bool isPaused = false;


    public void pausedGame()
    {

        if (isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }

    }
    
    
    
}

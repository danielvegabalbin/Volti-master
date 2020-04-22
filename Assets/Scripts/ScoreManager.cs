using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] PlayerCO1 playerCO1;

    [SerializeField] public float actualScore = 0.0f;
    [SerializeField] public float maxScore = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    [SerializeField] TextMeshProUGUI actualScore_TXT;
    TextMeshProUGUI maxScore_TXT;

    void Start()
    {
        actualScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualScore += Time.deltaTime;
        actualScore_TXT.text = ((int)actualScore).ToString();

        if (actualScore >= scoreToNextLevel)
        {
            LevelUp();
        }
    
    }

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;

        playerCO1.SetSpeed(difficultyLevel);

    }
}

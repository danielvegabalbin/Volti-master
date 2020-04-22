using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_CentralManager : MonoBehaviour
{
    [Header("Buttons for movement")]
    [SerializeField] GameObject leftMovement_BTN;
    [SerializeField] GameObject rightMovement_BTN;

    public bool SwipeActive = false;

    [SerializeField] Button Reset_BTN;



    // Start is called before the first frame update
    void Start()
    {
        Reset_BTN.onClick.AddListener(ResetGame);
    }

    // Update is called once per frame
    void Update()
    {

        #region Swipe or button change
        if (SwipeActive)
        {
            leftMovement_BTN.SetActive(false);
            rightMovement_BTN.SetActive(false);
        }
        else
        {
            leftMovement_BTN.SetActive(true);
            rightMovement_BTN.SetActive(true);
        }
        #endregion

    }

    void ResetGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int PickUpCount;

    void Awake()
    {
        PickUpCount = 0;
    }


    void OnGUI()
    {
        GUI.Label(new Rect((Screen.width / 2.0f), 100, 250, 400), string.Format("{0}", PickUpCount));
    }

}

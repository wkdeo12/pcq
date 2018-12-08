using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class GameManager : MonoBehaviour
{
    static public bool isGameOver = true;
    static private int score = 0;
    public int Score { get { return score; } }

    public GameObject startGUI;

    public void OnStartButtonClick()
    {
        startGUI.SetActive(false);
        isGameOver = false;
        FindObjectOfType<ObjectGenerator>().OnStart();
    }

    public void AddScore(int val)
    {
        score += val;
    }
}
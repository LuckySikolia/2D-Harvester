using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject startMenuPanel;
    //public GameObject leaderboardPanel;
    public GameObject resumeMenuPanel;
    public GameObject winUIPanel;
    public GameObject lossUIPanel;


    private void Start()
    {
        //initialize or hide elements
        startMenuPanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        resumeMenuPanel.SetActive(false);
        winUIPanel.SetActive(false);
        lossUIPanel.SetActive(false);
    }

    //adjust when score script has been set up
    public void UpdateScore(int score)
    {
        scoreText.text = ($"Score: {score}");
    }

    //update the timer to start from zero
    public void UpdateTimer(float timetaken)
    {
        timerText.text = ($"Score: {timetaken}");
    }

    //toogle the pause menu
    //TODO! WILL CONTINUE TOMORROW  
}

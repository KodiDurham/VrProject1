using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallThrowManager : MonoBehaviour
{
    public GameObject[] RoundsGameObjects;
    public Round[] roundScripts;
    public int Score;
    public int Timer;
    public Round curRound;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI TimeText;



    // Start is called before the first frame update
    void Start()
    {
        curRound = roundScripts[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int num)
    {
        curRound.currentScore += num;
        scoreText.text = "Score: " + curRound.currentScore;
        //displayCurren score
    }
}

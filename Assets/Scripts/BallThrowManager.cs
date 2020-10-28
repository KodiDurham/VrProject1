using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.AccessControl;
using UnityEngine.UI;
using UnityEngine.Rendering.LookDev;

public class BallThrowManager : MonoBehaviour
{
    public GameObject[] RoundsGameObjects;
    public Round[] roundScripts;
    public int score;
    public float timer;
    public Round curRound;
    public int curRoundInt;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI TimeText;

    public GameObject menuPanel;
    public GameObject scorePanel;   //play display
    public GameObject highScorePanel;

    [TextArea(3,5)]
    public string passText;
    [TextArea(3, 5)]
    public string highScoreText;
    [TextArea(3, 5)]
    public string failText;


    public Button play;
    public Button stop;
    public Button next;

    public Material wall;
    public Material target1;
    public Material target2;



    private bool isTimerActive;

    private GameObject welcomePanel;
    private GameObject scoreRePanel;
    private GameObject m_menuPanel;
    private GameObject roundSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        welcomePanel = menuPanel.transform.GetChild(0).gameObject;
        scoreRePanel = menuPanel.transform.GetChild(1).gameObject;
        m_menuPanel = menuPanel.transform.GetChild(2).gameObject;
        roundSelectPanel = menuPanel.transform.GetChild(3).gameObject;

        isTimerActive = false;
        curRound = roundScripts[0];
        curRoundInt = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && isTimerActive)
        {
            timer -= Time.deltaTime;
            updateTimerText();
            if (timer <= 0)
            {
                timer = 0f;
                if (score >= curRound.scoreToPass)
                    curRound.hasFinished = true;
                playStop();
                isTimerActive = false;
            }

        }
    }

    public void startMenuPlay()
    {
        scorePanel.SetActive(true);
        setRound(0);
        timer = curRound.time;
        //highScorePanel.SetActive(true);
        m_menuPanel.SetActive(false);
        play.interactable = true;
        stop.interactable = false;
        updateTimerText();
        updateRoundText();
    }

    public void startMenuSelect()
    {
        score = 0;
        roundSelectPanel.SetActive(true);
        m_menuPanel.SetActive(false);
        //more maybe required
        roundSelectPanel.transform.GetChild(1).GetComponent<ButtonRoundClick>().GetValues();
        roundSelectPanel.transform.GetChild(2).GetComponent<ButtonRoundClick>().GetValues();
        roundSelectPanel.transform.GetChild(3).GetComponent<ButtonRoundClick>().GetValues();
    }

    public void startScoreNext()
    {
        score = 0;
        switchRound();
        timer = curRound.time;
        scorePanel.SetActive(true);
        //highScorePanel.SetActive(true);
        scoreRePanel.SetActive(false);
        updateTimerText();
        updateRoundText();

    }

    public void startScoreReplay()
    {
        score = 0;
        timer = curRound.time;
        scorePanel.SetActive(true);
        //highScorePanel.SetActive(true);
        scoreRePanel.SetActive(false);
        updateTimerText();


    }

    public void playPlay()
    {
        score = 0;
        updateScore(0);
        activateRound();

        isTimerActive = true;
        play.interactable = false;
        stop.interactable = true;
    }

    public void playStop()
    {
        isTimerActive = false;
        timer = 0;
        DeavtivateRound();
        roundSelectPanel.SetActive(false);
        stop.interactable = false;
        play.interactable = true;
        scoreRePanel.SetActive(true);
        scorePanel.SetActive(false); // play Display

        string output;

        //if(score < curRound.scoreToPass)
        //{
        //    output = failText;
        //}else if (curRound.isHighScore(score))
        //{
        //    output = highScoreText;
        //    scoreRePanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "" + curRound.highScores.;
        //}
        //else
        //{
        //    output = passText;
        //}

        if (score < curRound.scoreToPass)
        {
            output = failText;
        }
        else
        {
            output = passText;
            curRound.hasFinished = true;
        }


        scoreRePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = output;
        scoreRePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + score;

        Debug.Log("" + (curRoundInt >= roundScripts.Length));

        if (score < curRound.scoreToPass || curRoundInt+1 >= roundScripts.Length)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }
    }


    public void switchRound()
    {
        curRoundInt++;
            curRound = roundScripts[curRoundInt];
            updateScore(0);
            updateRoundText();
    }

    public void DeavtivateRound()
    {
            RoundsGameObjects[curRoundInt].SetActive(false);
    }

    public void setRound(int num)
    {
        curRound = roundScripts[num];
        curRoundInt = num;
    }

    public void activateRound()
    {
        RoundsGameObjects[curRoundInt].SetActive(true);
        //wall.SetFloat("Vector1_E274ECF9", Mathf.Lerp(1,-.1f,5));
        //target1.SetFloat("Vector1_2C783208", Mathf.Lerp(1, -.1f, 5));
        //target2.SetFloat("Vector1_2C783208", Mathf.Lerp(1, -.1f, 5));
    }

    public void updateScore(int num)
    {
        score += num;
        scoreText.text = "Score: " + score;

    }

    public void updateRoundText()
    {
        roundText.text = "Round: " + curRound.roundNum;
    }

    public void updateTimerText()
    {
        TimeText.text = "" + Math.Round(timer);
    }


    public void triggerMenus()
    {
        menuPanel.SetActive(true);
        welcomePanel.SetActive(true);
        curRoundInt = 0;
    }

    public void triggerMenusOut()
    {

            isTimerActive = false;
            timer = 0;
            DeavtivateRound();
            scorePanel.SetActive(false); // play Display

            //highScorePanel.SetActive(false);
            welcomePanel.SetActive(false);
            scoreRePanel.SetActive(false);
            m_menuPanel.SetActive(false);
            roundSelectPanel.SetActive(false);
            menuPanel.SetActive(false);
    }
}

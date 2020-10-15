using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Round")]
public class Round : ScriptableObject
{
    public int roundNum;
    public int currentScore;
    public List<int> highScores;
    public List<int> highScoreNames;
    public int time;
    public GameObject targets;
    public bool hasFinished;

}

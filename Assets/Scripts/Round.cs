using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Round")]
public class Round : ScriptableObject
{
    public int roundNum;
    public int currentScore;
    public int[] highScores;
    public float time;
    public int scoreToPass;
    public bool hasFinished;

    public bool isHighScore(int num)
    {
        bool isHigh=false;

        for (int i =0; i<highScores.Length;i++)
        {


            if (num > highScores[i])
            {
                isHigh = true;
                highScores[0] = num;
                System.Array.Sort(highScores);
                break;
            }
        }


        return isHigh;
    }

}

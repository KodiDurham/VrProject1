using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderboardScript : MonoBehaviour
{
    public BallThrowManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {

    }

    public void updateText()
    {
        int childIndex = this.transform.GetSiblingIndex();
        int score = manager.curRound.highScores[manager.curRound.highScores.Length - childIndex];

        Debug.Log(""+childIndex+", " +score);

        this.GetComponent<TextMeshProUGUI>().text = "" + childIndex + ":  " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderboardScript : MonoBehaviour
{
    public BallThrowManager manager;
    public GameObject entry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnEnable()
    //{
    //    int[] currentRoundInts = manager.curRound.highScores;

    //    for(int i= 0; i < this.transform.childCount; i++)
    //    {
    //        Destroy(this.transform.GetChild(0));
    //    }
    //    GameObject entryCopy = Instantiate(entry);
    //    entryCopy.transform.parent = this.transform;
    //    entryCopy.GetComponent<TextMeshProUGUI>().text="Leaderboard";

    //    for(int i = 0; i < currentRoundInts.Length; i++)
    //    {
    //        entryCopy = Instantiate(entry);
    //        entryCopy.transform.parent = this.transform;
    //        entryCopy.GetComponent<TextMeshProUGUI>().text = ""+(i+1)+".\t"+currentRoundInts[i];
    //    }

    //}
}

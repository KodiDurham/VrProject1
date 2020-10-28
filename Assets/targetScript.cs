using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    public BallThrowManager manager;
    public int hitValue = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        if (this.transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        manager.updateScore(hitValue);
        this.gameObject.SetActive(false);
    }

}

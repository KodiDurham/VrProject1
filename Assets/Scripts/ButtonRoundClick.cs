using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonRoundClick : MonoBehaviour
{
    public TextMeshProUGUI roundName;

    int childIndex;

    public BallThrowManager manager;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        childIndex = this.transform.GetSiblingIndex();
        roundName.text = "Round " + childIndex;
        if (manager.roundScripts[childIndex-1].hasFinished)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }


    private void OnEnable()
    {

    }


    public void GetValues()
    {
        childIndex = this.transform.GetSiblingIndex();
        Debug.Log("" + (childIndex - 1)+" " +gameObject.name );
        if (manager.roundScripts[childIndex - 1].hasFinished)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        manager.setRound(childIndex-1);
    }
}

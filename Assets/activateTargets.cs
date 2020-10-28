using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTargets : MonoBehaviour
{

    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for (int i=0;i<targets.Length;i++)
        {
            targets[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

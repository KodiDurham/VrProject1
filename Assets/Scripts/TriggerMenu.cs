using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenu : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
            manager.triggerMenus();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
            manager.triggerMenusOut();
        
    }
}

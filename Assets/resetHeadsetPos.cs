using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHeadsetPos : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        OVRManager.display.RecenterPose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

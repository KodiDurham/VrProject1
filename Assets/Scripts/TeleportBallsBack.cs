using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallsBack : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;
    public shotScript test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = spawnPoint.transform.position;


        }
    }
}

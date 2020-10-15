using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallsBack : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;
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
            ball.transform.position = spawnPoint.transform.position;
        }
    }
}

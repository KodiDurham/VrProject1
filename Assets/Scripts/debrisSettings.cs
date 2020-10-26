using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisSettings : MonoBehaviour
{
    public Transform resetPoint;

    private void OnEnable()
    {
        this.transform.position = resetPoint.position;
        this.GetComponent<Rigidbody>().velocity=Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = resetPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

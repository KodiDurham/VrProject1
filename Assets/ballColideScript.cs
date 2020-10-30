using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballColideScript : MonoBehaviour
{
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        sound.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

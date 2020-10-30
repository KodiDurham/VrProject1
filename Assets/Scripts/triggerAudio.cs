using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAudio : MonoBehaviour
{

    public AudioSource sound;
    public AudioSource sound2;
    public bool isSecondSound=false;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isSecondSound)
        {
            sound.Stop();
            sound2.Play();
        }
        else 
        { 
            sound.Play(); 
        }

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    sound.enabled = false;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

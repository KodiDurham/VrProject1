using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAudio : MonoBehaviour
{

    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound.enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        Debug.Log(""+collision.gameObject.name);
            sound.enabled = true;
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

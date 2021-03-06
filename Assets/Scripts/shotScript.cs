﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotScript : MonoBehaviour
{
    public ParticleSystem barrel1;
    public ParticleSystem barrel2;

    public Transform shotPos1;
    public Transform shotPos2;

    RaycastHit hit;
    public float range = 1000;
    public GameObject shotPrefab;

    private OVRGrabbable grabbable;
    public OVRInput.Button shootButton;

    public AudioSource shotsound;

    // Start is called before the first frame update
    void Start()
    {
        barrel1.Stop();
        barrel2.Stop();

        grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            shootGun();
        }
    }

    public void shootGun()
    {
        //Vector3 forward = shotPos1.transform.TransformDirection(Vector3.forward);

        //if(Physics.Raycast(shotPos1.position,forward,out hit, range))
        //{
        //    GameObject laser = GameObject.Instantiate(shotPrefab, shotPos1.position, shotPos1.rotation) as GameObject;
        //    GameObject.Destroy(laser, 2f);
        //}

        //forward = shotPos2.transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(shotPos2.position, forward, out hit, range))
        //{
        //    GameObject laser = GameObject.Instantiate(shotPrefab, shotPos2.position, shotPos2.rotation) as GameObject;
        //   GameObject.Destroy(laser, 2f);
        //}

        shotsound.Play();
        VibeManager.singleton.triggerViberationController(shotsound.clip, grabbable.grabbedBy.GetController());

        GameObject laser = GameObject.Instantiate(shotPrefab, shotPos1.position, shotPos1.rotation) as GameObject;
        GameObject.Destroy(laser, 2f);

        Vector3 forward = shotPos1.transform.TransformDirection(Vector3.up);
        if (Physics.Raycast(shotPos1.position, forward, out hit, range))
        {
            laser.GetComponent<shotMovement>().changePoint(hit.point);
            if (hit.transform.tag == "target")
            {
                laser.GetComponent<shotMovement>().changeTarget(hit.transform.gameObject);
            }
        }

        laser = GameObject.Instantiate(shotPrefab, shotPos2.position, shotPos2.rotation) as GameObject;
        GameObject.Destroy(laser, 2f);

        barrel1.Stop();
        barrel2.Stop();
        barrel1.Play();
        barrel2.Play();

        forward = shotPos2.transform.TransformDirection(Vector3.up);

        if (Physics.Raycast(shotPos2.position, forward, out hit, range))
        {
            laser.GetComponent<shotMovement>().changePoint(hit.point);
            if (hit.transform.tag == "target")
            {
                laser.GetComponent<shotMovement>().changeTarget(hit.transform.gameObject);
            }

        }



        //Ray ray=shotPos1.position;
        //if(Physics.Raycast(ray, out hit, range))
        //{
        //    GameObject laser = GameObject.Instantiate(shotPrefab, shotPos1.position, shotPos1.rotation) as GameObject;
        //    GameObject.Destroy(laser, 2f);
        //}

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rayShot : MonoBehaviour
{
    public GameObject particleForMove;
    public Gradient goodHit;
    public Gradient badHit;


    public Camera cameraForRay;
    RaycastHit hit;

    float xRot = 0;
    float yRot = 0;

    bool isTargetMode = false;

    //Transform lastGoodHit;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        particleForMove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;

        xRot -= mouseY;
        yRot += mouseX;

        xRot = Mathf.Clamp(xRot, -90, 90);


        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);

        if (Input.GetMouseButtonDown(0) && isTargetMode == false)
        {
            isTargetMode = true;
            //initalize last good teleport location with the start of hitting the 
            //lastGoodHit = this.gameObject.transform;
        }
            


        if (isTargetMode/*Input.GetMouseButtonDown(0)*/)
        {

            particleForMove.SetActive(true);


            if (Input.GetMouseButtonDown(1))
            {
                isTargetMode = false;
                particleForMove.SetActive(false);

            }

            Ray ray = new Ray(cameraForRay.transform.position, cameraForRay.transform.forward);
            //Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            ParticleSystem indicator = particleForMove.GetComponent<ParticleSystem>();

            var gColor = indicator.colorOverLifetime;
            gColor.enabled = true;

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.tag == "ground")
                {
                    gColor.color = goodHit;


                    //Debug.Log("test");
                }
                else
                {
                    gColor.color = badHit;
                }

                particleForMove.transform.position = new Vector3(hit.point.x, particleForMove.transform.position.y, hit.point.z); //hit.transform.position;

                if (objectHit.tag == "ground" && Input.GetMouseButtonUp(0))
                {

                    this.transform.position = new Vector3(hit.point.x, this.transform.position.y, hit.point.z); //hit.transform.position;
                    isTargetMode = false;
                    particleForMove.SetActive(false);

                }
                else if (Input.GetMouseButtonUp(0) && (objectHit.tag != "ground" || objectHit == null))
                {
                    

                    isTargetMode = false;

                    particleForMove.SetActive(false);
                }
            }
            else
            {
                
                gColor.color = badHit;

                if (Input.GetMouseButtonUp(0))
                {
                    //teleportTo(lastGoodHit.position, this.gameObject);

                    isTargetMode = false;

                    particleForMove.SetActive(false);
                }

                
            }
        }
    }
}

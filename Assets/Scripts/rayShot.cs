using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayShot : MonoBehaviour
{
    public Camera camera;
    RaycastHit hit;

    float xRot = 0;
    float yRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;

        xRot -= mouseY;
        yRot += mouseX;

        xRot = Mathf.Clamp(xRot, -90, 90);

        Debug.Log(xRot +", " +yRot);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);


        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            //Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.tag == "ground")
                {
                    Debug.Log(Input.mousePosition);
                    this.transform.position = new Vector3(hit.point.x, this.transform.position.y, hit.point.z); //hit.transform.position;
                }

            }
        }
    }
}

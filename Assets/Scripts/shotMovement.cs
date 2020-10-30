using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shotMovement : MonoBehaviour
{
    public GameObject hitExplode;
    public float speed = 1000f;
    private Vector3 endPos;
    private bool hasPoint=false;
    public float distError = 1f;
    public GameObject target;
    private bool hasTarget=false;

    public GameObject hitsound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position += transform.up * Time.deltaTime * speed;
        if (hasPoint)
        {
            if (Vector3.Distance(transform.position, endPos)<distError)
            {
                GameObject sound = Instantiate(hitsound, endPos, Quaternion.Inverse(transform.rotation));
                GameObject explosion = Instantiate(hitExplode, endPos, Quaternion.Inverse(transform.rotation));
                Destroy(gameObject);
                Destroy(explosion, 1f);
                Destroy(sound, 1f);
                if (hasTarget)
                {
                    target.GetComponent<targetScript>().hit();
                }

            }
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

    }

    public void changePoint(Vector3 num)
    {
        endPos = num;
        hasPoint = true;

    }

    public void changeTarget(GameObject t)
    {
        hasTarget = true;
        target = t;
    }

    void explode()
    {
        if(hitExplode != null)
        {
            GameObject explosion = Instantiate(hitExplode, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }

}

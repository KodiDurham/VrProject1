using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float moveSpeed=3;

    public bool isMovingTarget=true;

    bool isGoingA=true;

    public Transform startTransform;

    private void OnEnable()
    {
        this.transform.position = startTransform.position;
        isGoingA = true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingTarget)
        {
            if (isGoingA)
            {
                if (this.transform.position != pointA.position)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, pointA.position, Time.deltaTime * moveSpeed);
                }
                else
                {
                    isGoingA = false;
                }

            }
            else
            {
                if (this.transform.position != pointB.position)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, pointB.position, Time.deltaTime * moveSpeed);
                }
                else
                {
                    isGoingA = true;
                }
            }
        }
    }
}

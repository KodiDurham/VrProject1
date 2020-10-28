using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferrosWheelTargets : MonoBehaviour
{
    // Start is called before the first frame update
    public enum RotType { step, contstant };
    public enum Direction { up,down,foward,back,left, right }
    public RotType type = RotType.step;
    public Direction centerDirection = Direction.up;
    public RotType targetType = RotType.step;
    public Direction targetDirection = Direction.up;
    public GameObject[] targets;

    public bool isRotTarget = true;
    public float centerSpeed = 2;
    public float targetSpeed = 2;
    public float step=60;

    Quaternion rotation;
    Quaternion[] rotations;
    Vector3 centerDir;
    Vector3 targetDir;

    // Start is called before the first frame update
    void Start()
    {
        switch (centerDirection)
        {
            case Direction.up:
                centerDir = Vector3.up;
                break;
            case Direction.down:
                centerDir = Vector3.down;
                break;
            case Direction.foward:
                centerDir = Vector3.forward;
                break;
            case Direction.back:
                centerDir = Vector3.back;
                break;
            case Direction.left:
                centerDir = Vector3.left;
                break;
            case Direction.right:
                centerDir = Vector3.right;
                break;

            default:
                break;
        }

        switch (targetDirection)
        {
            case Direction.up:
                targetDir = Vector3.up;
                break;
            case Direction.down:
                targetDir = Vector3.down;
                break;
            case Direction.foward:
                targetDir = Vector3.forward;
                break;
            case Direction.back:
                targetDir = Vector3.back;
                break;
            case Direction.left:
                targetDir = Vector3.left;
                break;
            case Direction.right:
                targetDir = Vector3.right;
                break;

            default:
                break;
        }

        rotation = transform.rotation;
        rotations=new Quaternion[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            rotations[i] = targets[i].transform.rotation;
        }

    }

    private void OnEnable()
    {
        //set base rotation
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.rotation = Quaternion.Euler(90, -90, 0);
        rotation = transform.rotation;

        rotations = new Quaternion[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            
            targets[i].SetActive(true);
            //    //set target base rotation
            targets[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            targets[i].transform.rotation = Quaternion.Euler(-90,0,0);
            rotations[i] = targets[i].transform.rotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case RotType.step:
                if (transform.rotation == rotation)
                {
                    rotation *= Quaternion.AngleAxis(step, centerDir);
                }

                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, centerSpeed * Time.deltaTime);
                break;

            case RotType.contstant:
                transform.Rotate(centerDir, centerSpeed * Time.deltaTime, Space.Self);
                break;

            default:
                break;
        }
        switch (targetType)
        {
            case RotType.step:

                //for (int i = 0; i < targets.Length; i++)
                //{
                //    if (targets[i].transform.rotation == rotations[i])
                //    {
                //        rotations[i] *= Quaternion.AngleAxis(step, targetDir);
                //    }

                //    targets[i].transform.rotation = Quaternion.Lerp(targets[i].transform.rotation, rotations[i], targetSpeed * Time.deltaTime);
                //}

                break;

            case RotType.contstant:

                for (int i = 0; i < targets.Length; i++)
                {
                    if(targets[i].active)
                        targets[i].transform.Rotate(targetDir, targetSpeed * Time.deltaTime, Space.World);
                }

                break;



            default:
                break;
        }
    }
}

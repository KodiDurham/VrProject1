using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public ParticleSystem visualEffect;
    public BallThrowManager Manager;
    public int goalValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        visualEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("GOOOOAAAAL!!!");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOOOOAAAAL!!!");
        visualEffect.Play();
        Manager.updateScore(goalValue);

    }
}

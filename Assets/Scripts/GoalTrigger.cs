using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public ParticleSystem visualEffect;
    public BallThrowManager Manager;
    public AudioSource sound;
    public int goalValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        sound.Stop();
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

    private void OnEnable()
    {
        sound.Stop();
        visualEffect.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("GOOOOAAAAL!!!");
        if (other.tag=="ball")
        {
            sound.Play();
            visualEffect.Play();
            Manager.updateScore(goalValue);
        }
    }
}

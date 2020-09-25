using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightflicker : MonoBehaviour
{

    public Light lightToF;
    public float minLightLevel=0;
    public float maxLightLevel=6;
    public int smooth = 5;
    public AudioSource sound;
    public float cutSoundAt = 2;

    public GameObject lightOn;
    public GameObject lightOff;

    Queue<float> smoothQ;
    float lSum=0;


    public void Reset()
    {
        smoothQ.Clear();
        lSum = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        smoothQ = new Queue<float>(smooth);
    }

    // Update is called once per frame
    void Update()
    {
        while (smoothQ.Count >= smooth)
        {
            lSum -= smoothQ.Dequeue();
        }

        float RanVal = Random.Range(minLightLevel, maxLightLevel);
        smoothQ.Enqueue(RanVal);
        lSum += RanVal;

        float avgLight = lSum / (float)smoothQ.Count;

        if (avgLight <= cutSoundAt)
        {
            sound.enabled = false;
            lightOn.SetActive(false);
            lightOff.SetActive(true);
        }
        else
        {
            sound.enabled = true;
            lightOn.SetActive(true);
            lightOff.SetActive(false);
        }
        lightToF.intensity = avgLight;

    }
}

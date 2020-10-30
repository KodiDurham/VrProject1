using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    public BallThrowManager manager;
    public int hitValue = 10;
    public GameObject hitSound;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        if (this.transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        GameObject sound = Instantiate(hitSound, Vector3.zero, Quaternion.Inverse(transform.rotation));
        Destroy(sound, 1f);
        manager.updateScore(hitValue);
        this.gameObject.SetActive(false);
        
    }

}

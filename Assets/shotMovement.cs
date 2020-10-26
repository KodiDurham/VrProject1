using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shotMovement : MonoBehaviour
{
    public GameObject hitExplode;
    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        explode();
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

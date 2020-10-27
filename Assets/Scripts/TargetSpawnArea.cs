using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnArea : MonoBehaviour
{
    public GameObject target;

    Vector3 origin;
    Vector3 range;
    Vector3 randomRange;
    public Color gizmoColor = new Color(.5f,.5f,.5f,.2f);
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        origin = this.transform.position;
        range = transform.localScale / 2.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = +Time.deltaTime;
        if (((int)timer) % 5 == 0)
        {
            Instantiate(target, getRandomPoint(), Quaternion.identity);
        }
    }

    Vector3 getRandomPoint()
    {
        randomRange = new Vector3(Random.Range(-range.x, range.x),
            Random.Range(-range.y, range.y),
            Random.Range(-range.z, range.z));

        return origin + randomRange;
    }

    private void OnDrawGizmos()
    {
        origin = this.transform.position;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(origin, transform.localScale);
    }
}

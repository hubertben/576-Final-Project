using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_motion : MonoBehaviour
{
    // Update is called once per frame

    // starting time
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 15;

        // if starttime hits 3 seconds, destory the object
        if (Time.time - startTime > 20)
        {
            Destroy(gameObject);
        }

        // subtract .01 seconds from starttime
        startTime -= .01f;

    }
}

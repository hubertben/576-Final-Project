using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_cloud_behavior : MonoBehaviour
{
    private float life = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life >= 0.9)
            Destroy(gameObject);
    }
}

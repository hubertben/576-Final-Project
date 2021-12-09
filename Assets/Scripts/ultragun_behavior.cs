using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultragun_behavior : MonoBehaviour
{

    private float lifetime;
    private float death;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 0;
        death = 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 3;


        lifetime += Time.deltaTime;
        if (lifetime >= death)
            Destroy(gameObject);
    }
}

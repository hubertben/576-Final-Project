using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultragun_gun_behavior : MonoBehaviour
{
    public GameObject projectile;

    private float shot_timer;
    private float shot_timer_threshold;
    // Start is called before the first frame update
    void Start()
    {
        shot_timer = 0;
        shot_timer_threshold = 1;
    }

    // Update is called once per frame
    void Update()
    {
        shot_timer += Time.deltaTime;
        if(shot_timer >= shot_timer_threshold)
        {
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.name += "ultragun";
            shot_timer -= shot_timer_threshold;
        }
    }
}

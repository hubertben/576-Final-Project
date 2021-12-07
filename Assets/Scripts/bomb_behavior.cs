using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_behavior : MonoBehaviour
{
    public float bomb_timer_threshold;
    public float force_strength;
    private float bomb_timer;
    void Start()
    {
        bomb_timer = 0.0f;
        //this is just a hack to make thrown bombs visible
        if(gameObject.name.Contains("Clone")) 
        {
            bomb_timer = bomb_timer_threshold;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bomb_timer += Time.deltaTime;
        //only display a bomb over our head if we can throw one
        if(bomb_timer < bomb_timer_threshold)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        //don't go past the limit
        if (bomb_timer > bomb_timer_threshold)
        {
            bomb_timer = bomb_timer_threshold;
        }
        if(Input.GetMouseButtonDown(0) && bomb_timer >= bomb_timer_threshold && !gameObject.name.Contains("Clone"))
        {
            GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
            clone.GetComponent<MeshRenderer>().enabled = true;
            clone.GetComponent<Rigidbody>().useGravity = true;
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.up * force_strength); //we use TRANSFORM.UP here because I rotated the model to make more sense
            bomb_timer -= bomb_timer_threshold;
        }
    }
}

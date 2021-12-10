using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_potion : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip healthSound;
    private Transform initTrans;

    private void Start()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        initTrans = gameObject.transform;
    }

    private void Update()
    {
        gameObject.transform.position = initTrans.position;
        gameObject.transform.rotation = initTrans.rotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            audio.PlayOneShot(healthSound);
            GameObject.FindObjectOfType<player_movement>().health += 30;
            
            Destroy(gameObject);
        }
    }
}

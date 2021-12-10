using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_potion : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip healthSound;

    private void Start()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();    
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            audio.PlayOneShot(healthSound);
            GameObject.FindObjectOfType<player_movement>().health += 30;
            
            Destroy(gameObject);
        }

        if(collision.gameObject.name.Contains("Projectile")||collision.gameObject.name.Contains("Bomb")||collision.gameObject.name.Contains("Sword")) 
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}

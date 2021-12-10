using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_potion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
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

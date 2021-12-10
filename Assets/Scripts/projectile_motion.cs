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
        transform.position += gameObject.name.Contains("Master") ? transform.up * Time.deltaTime * 10 : transform.forward * Time.deltaTime * 15;

        // if starttime hits 3 seconds, destory the object
        if (Time.time - startTime > 20)
        {
            Destroy(gameObject);
        }

        // subtract .01 seconds from starttime
        startTime -= .01f;

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name.Contains("Wall"))
        {
            Destroy(gameObject);
        }

        if(name.Contains("BOSS"))
        {
            if(collision.gameObject.name == "Player")
            {
                //decrement player health by dmg
                GameObject.FindObjectOfType<player_movement>().health -= 10;
                
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.name == "Boss")
            {
                GameObject inventory = GameObject.Find("Player");
                float current_damage = inventory.GetComponent<open_inventory_menu>().currentWeapon.damage;
                Debug.Log(current_damage);

                //decrement boss health by dmg
                GameObject.FindObjectOfType<boss_behavior>().health -= current_damage;
                Destroy(gameObject);
            }
        }
    }
}

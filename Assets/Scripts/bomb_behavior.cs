using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_behavior : MonoBehaviour
{
    public GameObject spawnSpot; //empty gameobject to spawn bombs at 
    public GameObject smokeCloud; //smoke cloud to spawn after bomb makes contace with something
    public float bomb_timer_threshold; //how long in between 
    public float force_strength; //howw hard a bomb is thrown

    private float bomb_timer;

    void Start()
    {
        bomb_timer = 0.0f;
        
        //this is just a hack to make thrown bombs visible
        if(gameObject.name.Contains("Clone")) 
        {
            bomb_timer = bomb_timer_threshold;
        }
        else
        {
            //essentially we always have one parent bomb that's just chilling here
            GetComponent<CapsuleCollider>().enabled = false;
        }

        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bomb_timer += Time.deltaTime;
        if (bomb_timer < bomb_timer_threshold)
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

        //if we can throw a bomb, do it
        if(Input.GetMouseButtonDown(0) && bomb_timer >= bomb_timer_threshold && !gameObject.name.Contains("Clone"))
        {
            GameObject clone = Instantiate(gameObject, spawnSpot.transform.position, spawnSpot.transform.rotation);
            clone.GetComponent<MeshRenderer>().enabled = true;
            clone.GetComponent<CapsuleCollider>().enabled = true;
            clone.GetComponent<Rigidbody>().useGravity = true;
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.up * force_strength); //we use TRANSFORM.UP here because I rotated the model to make more sense
            bomb_timer -= bomb_timer_threshold;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //Damage the other object in some way
        Instantiate(smokeCloud, transform.position, transform.rotation);

        
        if(collision.gameObject.name.Contains("Boss"))
        {
            //decrement boss health
            GameObject inventory = GameObject.Find("Player");
            float current_damage = inventory.GetComponent<open_inventory_menu>().currentWeapon.damage;

            GameObject.FindObjectOfType<boss_behavior>().health -= current_damage;
        }

        //MasterBomb special attack
        if(gameObject.name.Contains("Master") && !gameObject.name.Contains("Split"))
        {
            //frontmost vertex of triangle
            GameObject clone = Instantiate(gameObject, gameObject.transform.position + new Vector3(1f, 5f, 1f), gameObject.transform.rotation);
            clone.name += "Split";

            GameObject clone1 = Instantiate(gameObject, gameObject.transform.position + new Vector3(-1f, 5f, -1f), gameObject.transform.rotation);
            clone1.name += "Split";

            GameObject clone2 = Instantiate(gameObject, transform.position + new Vector3(0, 8f, 0), transform.rotation);
            clone2.name += "Split";
        }

        Destroy(gameObject);
    }
}

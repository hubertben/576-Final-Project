using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_behavior : MonoBehaviour
{
    private Animator animcon;
    private Animator playerAnimCon;
    public GameObject MasterSwordProjectile;
    public GameObject player;

    public AudioSource audio;
    public AudioClip swordSound;

    private void Start()
    {
        animcon = GetComponent<Animator>();
        playerAnimCon = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.x, 
                                         playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.y + 0.6f, 
                                         playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.z);
        if (Input.GetMouseButtonDown(0) && animcon.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {

            audio.PlayOneShot(swordSound);

            animcon.SetTrigger("SwingingSword");
            if(gameObject.name.Contains("Master"))
            {
                Quaternion rotation = Quaternion.LookRotation(player.transform.up, player.transform.forward);
                Vector3 position = player.transform.position + 3f * player.transform.forward;
                position.y += 1;
                Instantiate(MasterSwordProjectile, position, rotation);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision: " + collision.gameObject.name);
        //reflect back projectiles
        if(collision.gameObject.name.Contains("Projectile") && (gameObject.name.Contains("Advanced") || gameObject.name.Contains("Master")))
        {
            collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Inverse(collision.gameObject.GetComponent<Transform>().rotation);
        }

        if(collision.gameObject.name.Contains("Boss"))
        {
            GameObject inventory = GameObject.Find("Player");
            float current_damage = inventory.GetComponent<open_inventory_menu>().currentWeapon.damage;
            Debug.Log("hit!!!");

            //decrement boss health by dmg
            GameObject.FindObjectOfType<boss_behavior>().health -= current_damage;
        }
    }
}

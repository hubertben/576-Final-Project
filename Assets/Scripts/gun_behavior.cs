using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_behavior : MonoBehaviour
{
    private Animator animcon;
    public Animator playerAnimCon;
    public GameObject projectile;
    public GameObject ultragun;

    public AudioSource audio;
    public AudioClip gunSound;

    // Start is called before the first frame update
    void Start()
    {
        animcon = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position;
        if (Input.GetMouseButtonDown(0) && animcon.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            audio.PlayOneShot(gunSound);
            animcon.SetTrigger("ShootingProjectile");
            shoot();
        }
    }

    void shoot()
    {
        if(name.Contains("Basic"))
        {
            Vector3 proj_dir = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(projectile, proj_dir, transform.rotation);
        }
        else if(name.Contains("Advanced"))
        {
            Vector3 proj1 = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
            Vector3 proj2 = new Vector3(transform.position.x - 2, transform.position.y + 0.5f, transform.position.z + 1f);
            Vector3 proj3 = new Vector3(transform.position.x + 2, transform.position.y + 0.3f, transform.position.z - 1f);
            Instantiate(projectile, proj1, transform.rotation);
            Instantiate(projectile, proj2, transform.rotation);
            Instantiate(projectile, proj3, transform.rotation);
        }
        else //master
        {
            Instantiate(ultragun, transform.position, transform.rotation);
        }
    }
}

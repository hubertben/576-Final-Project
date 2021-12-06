using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_behavior : MonoBehaviour
{
    private Animator animcon;
    public Animator playerAnimCon;
    public GameObject projectile;
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
            animcon.SetTrigger("ShootingProjectile");
            Vector3 proj_dir = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(projectile, proj_dir, transform.rotation);
        }
    }
}

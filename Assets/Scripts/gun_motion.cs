using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_motion : MonoBehaviour
{
    private Animator animcon;
    public Animator playerAnimCon;
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
        }
    }
}

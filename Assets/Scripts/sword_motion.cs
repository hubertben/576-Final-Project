using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_motion : MonoBehaviour
{
    private Animator animcon;
    public Animator playerAnimCon;

    private void Start()
    {
        transform.rotation = new Quaternion();
        animcon = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.x, 
                                         playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.y + 0.6f, 
                                         playerAnimCon.GetBoneTransform(HumanBodyBones.RightHand).position.z);
        if (Input.GetMouseButtonDown(0) && animcon.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animcon.SetTrigger("SwingingSword");
            if(gameObject.name.Contains("Master"))
            {
                //spawn master sword projectile
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.name.Contains("Advanced"))
        {
            Debug.Log("slash");
            //reflect projectile
                //check that the name of the object in the collision is enemy projectile or something
                //invert its direction
        }
        else
        {
            //if name is not BigBossEnemy destroy it
        }
    }
}

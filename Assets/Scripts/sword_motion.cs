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
        }
    }
}

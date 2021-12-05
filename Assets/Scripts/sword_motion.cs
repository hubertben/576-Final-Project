using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_motion : MonoBehaviour
{
    private Animator animcon;

    private void Start()
    {
        transform.rotation = new Quaternion();
        animcon = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0) && animcon.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animcon.SetTrigger("SwingingSword");
        }
    }
}

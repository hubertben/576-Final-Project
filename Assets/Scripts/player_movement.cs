using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Animator animation_controller;
    private CharacterController character_controller;
    //various velocities
    public Vector3 movement_direction;
    public float velocity;
    public float walking_velocity;
    private float running_velocity;
    private float backwards_velocity;
    private float crouch_velocity;
    private float jump_velocity;

    // Start is called before the first frame update
    void Start()
    {
        animation_controller = GetComponent<Animator>();
        character_controller = GetComponent<CharacterController>();
        movement_direction = new Vector3(0.0f, 0.0f, 0.0f);
        velocity = 0.0f;
        walking_velocity = 5f;
        running_velocity = 2 * walking_velocity;
        backwards_velocity = walking_velocity / -1.5f;
        crouch_velocity = walking_velocity / 2.0f;
        jump_velocity = 3 * walking_velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animation_controller.SetTrigger("isAttacking");
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))) //forward motion of any kind
        {
            animation_controller.SetBool("isWalking", true);
            velocity = Mathf.Min(velocity + 0.025f, walking_velocity);

            if (Input.GetKey(KeyCode.LeftShift)) //running
            {
                animation_controller.SetBool("isRunning", true);
                velocity = running_velocity;
            }
            else
            {
                animation_controller.SetBool("isRunning", false);
                velocity = walking_velocity;
            }
        }
        else //no forward motion
        {
            animation_controller.SetBool("isWalking", false);
            animation_controller.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //turn left
        {
            transform.Rotate(new Vector3(0.0f, -0.75f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //turn right
        {
            transform.Rotate(new Vector3(0.0f, 0.75f, 0.0f));
        }

        if(animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Idle01") || animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Idle03")) //if no forward/backward motion at all, or in a menu
        {
            velocity = 0;
        }

        float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
        float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
        movement_direction = new Vector3(xdirection, 0.0f, zdirection);
        character_controller.Move(movement_direction * velocity * Time.deltaTime);

        //stay in bounds
        if(transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
        
    }
}

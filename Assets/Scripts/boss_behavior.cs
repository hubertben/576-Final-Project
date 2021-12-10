using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss_behavior : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    private Animator animcon;
    public float health;

    private float shoot_attack_timer;
    private float shoot_attack_timer_threshold;

    private float pause_timer;
    private float pause_timer_lower_threshold = 10; //when we hit this mark, start pausing
    private float pause_timer_upper_threshold = 15; //when we hit this mark, stop pausing

    private Vector3 dir_to_player;

    public AudioSource audio;
    public AudioClip bossSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        shoot_attack_timer_threshold = 3f;
        health = 10000;
        player = GameObject.Find("Player");
        animcon = gameObject.GetComponent<Animator>();

        health = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            SceneManager.LoadScene(3);
        }

        dir_to_player = player.transform.position - transform.position;
        dir_to_player.Normalize();
        
        shoot_attack_timer += Time.deltaTime;
        //if (shoot_attack_timer >= shoot_attack_timer_threshold) shoot_attack_timer = shoot_attack_timer_threshold;
        
        pause_timer += Time.deltaTime;

        //give player opportunity to hit boss
        if (pause_timer >= pause_timer_lower_threshold)
        {
            animcon.SetBool("pausing", true);
            if (pause_timer >= pause_timer_upper_threshold)
            {
                pause_timer = 0;
            }
        } 
        //boss does its thing
        else
        {
            animcon.SetBool("pausing", false);

            if (shoot_attack_timer < shoot_attack_timer_threshold)
            {
                animcon.SetBool("walking", true);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
            }
            else
            {

                audio.PlayOneShot(bossSound);

                animcon.SetBool("walking", false);

                Vector3 future_pos = player.transform.position;
                float delta_pos = Mathf.Infinity;
                Vector3 shooting_direction = dir_to_player;
                for (int i = 0; i < 1000; i++)
                {
                    float distance = Vector3.Magnitude(future_pos - transform.position);
                    float look_ahead_time = distance / 10;
                    Vector3 previous_future_pos = future_pos;
                    future_pos = player.transform.position + look_ahead_time * player.GetComponent<player_movement>().velocity * player.GetComponent<player_movement>().movement_direction;
                    delta_pos = Vector3.Magnitude(future_pos - previous_future_pos);
                }
                shooting_direction = future_pos - transform.position;
                shooting_direction.y = 0;
                shooting_direction.Normalize();

                float angle_to_rotate_turret = Mathf.Rad2Deg * Mathf.Atan2(shooting_direction.x, shooting_direction.z);
                transform.eulerAngles = new Vector3(0.0f, angle_to_rotate_turret, 0.0f);

                GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
                clone.name += "BOSS";
                shoot_attack_timer -= shoot_attack_timer_threshold;
            }
        }
    }
}

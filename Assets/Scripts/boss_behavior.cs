using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_behavior : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    private float health;
    private float attack_timer;
    private float attack_timer_threshold;
    private Vector3 dir_to_player;

    // Start is called before the first frame update
    void Start()
    {
        attack_timer_threshold = 1.5f;
        health = 1000;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir_to_player = player.transform.position - transform.position;
        dir_to_player.Normalize();
        attack_timer += Time.deltaTime;
        if (attack_timer < attack_timer_threshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            Vector3 future_pos = player.transform.position;
            float delta_pos = Mathf.Infinity;
            Vector3 shooting_direction = dir_to_player;
            for(int i = 0; i < 1000; i++)
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

            GameObject clone = Instantiate(projectile, transform.position + new Vector3(0, 1, 0), transform.rotation);
            clone.name += "BOSS";
            attack_timer -= attack_timer_threshold;
        }
    }
}

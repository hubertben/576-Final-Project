using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class level : MonoBehaviour
{
    public int width = 80;   // size of level (default 16 x 16 blocks)
    public int length = 80;
    public GameObject boss_prefab;
    public GameObject fir_tree_prefab;
    public GameObject oak_tree_prefab;
    public GameObject palm_tree_prefab;
    public GameObject poplar_tree_prefab;
    public GameObject platform_prefab;
    public int health_up_bound = 1;

    public Slider player_health_bar;
    public float player_health = 1.0f;

    // Use this for initialization
    void Start()
    {
        //Initialization for the boss
        int boss_x = Random.Range(-35, 35);
        int boss_z = Random.Range(-35, 35);

        GameObject boss = Instantiate(boss_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        boss.name = "Boss";
        boss.transform.position = new Vector3(boss_x, 0.0f, boss_z); 



        //Initialization for the trees
        for(int i = 10; i <= width-10; i+=5)
        {
            for(int j = 10; j <= length-10; j+=5)
            {
                int p = Random.Range(0, 25);
                if(p > 15)
                {
                    int tree_num = Random.Range(0, 5);
                    float tree_x = (float)i - 40.0f;
                    float tree_z = (float)j - 40.0f;
                    tree_x = Random.Range(tree_x - 5, tree_x + 5);
                    tree_z = Random.Range(tree_z - 5, tree_z + 5);

                    GameObject tree_prefab;

                    switch (tree_num)
                    {
                    case 4:
                        tree_prefab = fir_tree_prefab;
                        break;
                    case 3:
                        tree_prefab = oak_tree_prefab;
                        break;
                    case 2:
                        tree_prefab = palm_tree_prefab;
                        break;
                    case 1:
                        tree_prefab = poplar_tree_prefab;
                        break;
                    default:
                        tree_prefab = fir_tree_prefab;
                        break;
                    }
                    GameObject temp = Instantiate(tree_prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.name = "TREE";
                    temp.transform.position = new Vector3(tree_x, 0.0f, tree_z); 
                }
                else if(p < health_up_bound)
                {
                    float platform_x = (float)i - 35.0f;
                    float platform_z = (float)j - 35.0f;
                    platform_x = Random.Range(platform_x - 5, platform_x + 5);
                    platform_z = Random.Range(platform_z - 5, platform_z + 5);

                    GameObject temp = Instantiate(platform_prefab, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.name = "Platform";
                    temp.transform.position = new Vector3(platform_x, 0.0f, platform_z); 

                }
            }
        }
    }

    public void SetHealth(float health)
    {
        player_health_bar.value = health;
    }

    void Update()
    {

        SetHealth(player_health);

    }
}

   


    

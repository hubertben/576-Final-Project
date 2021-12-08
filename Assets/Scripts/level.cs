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


    // Use this for initialization
    void Start()
    {

        for(int i = 5; i < width-5; i+=5)
        {
            for(int j = 5; j < length-5; j+=5)
            {
                int tree_num = Random.Range(0, 5);
                float tree_x = (float)i - 35.0f;
                float tree_z = (float)j - 35.0f;
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
        }
    }

    void Update()
    {
    }
}

   


    

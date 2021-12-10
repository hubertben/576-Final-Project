using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class fileIO : MonoBehaviour
{
    public string[] unlocks;
    public GameObject inventory;
    public string path = "Assets/unlocks.txt";
    // Start is called before the first frame update
    void Start()
    { 
        inventory = GameObject.Find("Player");

        string[] lines = System.IO.File.ReadAllLines(path);
        string[][] d = new string[lines.Length][];
        // clean lines by splitting at the colon
        for (int i = 0; i < lines.Length; i++)
        {   
            //Debug.Log(lines[i].Split(':')[0] + " " + lines[i].Split(':')[1]);
            d[i] = lines[i].Split(':');
        }
        
        for(int i = 0; i < 9; i++){
            if (d[i][1] == "true"){
                inventory.GetComponent<open_inventory_menu>().unlock(d[i][0]);
            }
        }

        


    }

    void write(string s)
    {
        System.IO.File.WriteAllText(path, s);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

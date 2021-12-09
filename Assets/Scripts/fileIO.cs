using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class fileIO : MonoBehaviour
{
    public int[] unlocks;
    public GameObject inventory;
    public string path = "Assets/unlocks.txt";
    // Start is called before the first frame update
    void Start()
    { 
        inventory = GameObject.Find("Player");

        string[] lines = System.IO.File.ReadAllLines(path);
        
        for(int i = 0; i < lines.Length; i++){
            if (lines[i] == "true"){
                inventory.GetComponent<open_inventory_menu>().unlock_item(i);
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

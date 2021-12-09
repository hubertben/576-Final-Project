using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDeath : MonoBehaviour
{
    public GameObject chooseMenu;
    public GameObject inventory;

    void onDeath_()
    {
        chooseMenu = GameObject.Find("ChooseMenu");
        inventory = GameObject.Find("Player");

        chooseMenu.SetActive(true);
    }

    void selectItems(){
        List<Weapon> weapons = inventory.GetComponent<open_inventory_menu>().returnFalseItems();

        Weapon weapon = weapons[Random.Range(0, weapons.Count)];
        
    }

}

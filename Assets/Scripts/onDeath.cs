using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onDeath : MonoBehaviour
{
    public GameObject chooseMenu;
    public GameObject inventory;
    public GameObject button1;
    public GameObject button2;
    public GameObject text1;
    public GameObject text2;
    
    //private Animator animation_controller;
    void Start()
    {
        inventory = GameObject.Find("Player");
        init_buttons();
    }

    void selectItems(){
        List<Weapon> weapons = inventory.GetComponent<open_inventory_menu>().get_shop_weapons();

        if(weapons.Count > 1){
            // choose 2 random distinct weapons from the list of weapons
            int rand1 = Random.Range(0, weapons.Count);
            int rand2 = Random.Range(0, weapons.Count);
            while (rand2 == rand1)
            {
                rand2 = Random.Range(0, weapons.Count);
            } 

            Weapon weapon1 = weapons[rand1];
            Weapon weapon2 = weapons[rand2];

            // set the text of the buttons to the names of the weapons
            button1.GetComponentInChildren<Text>().text = weapon1.get_full_weapon_type();
            button2.GetComponentInChildren<Text>().text = weapon2.get_full_weapon_type();

            // set the text of the texts to the damage of the weapons
            text1.GetComponentInChildren<Text>().text = "Damage: " + weapon1.damage.ToString();
            text2.GetComponentInChildren<Text>().text = "Damage: " + weapon1.damage.ToString();

        }else if(weapons.Count == 1){
            // if there is only one weapon in the list, set the text of the buttons to the name of the weapon
            button1.GetComponentInChildren<Text>().text = "Damage: " + weapons[0].get_full_weapon_type();
            button2.GetComponentInChildren<Text>().text = "Level Up to Unlock More";

            // set the text of the texts to the damage of the weapon
            text1.GetComponentInChildren<Text>().text = "Damage: " + weapons[0].damage.ToString();
            text2.GetComponentInChildren<Text>().text = "Level Up to Unlock More";
        }else{
            // if there are no weapons in the list, set the text of the buttons to "Level Up to Unlock More"
            button1.GetComponentInChildren<Text>().text = "Level Up to Unlock More";
            button2.GetComponentInChildren<Text>().text = "Level Up to Unlock More";

            // set the text of the texts to "Level Up to Unlock More"
            text1.GetComponentInChildren<Text>().text = "Level Up to Unlock More";
            text2.GetComponentInChildren<Text>().text = "Level Up to Unlock More";
        }
        
    }

    private void init_buttons(){
        Button btn = button1.GetComponent<Button>();
	    btn.onClick.AddListener(() => {
            inventory.GetComponent<open_inventory_menu>().unlock_item_by_string(button1.GetComponentInChildren<Text>().text);
            //inventory.GetComponent<open_inventory_menu>().unlock_item(2);
            chooseMenu.SetActive(false);
        });

        btn = button2.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            inventory.GetComponent<open_inventory_menu>().unlock_item_by_string(button2.GetComponentInChildren<Text>().text);
            //inventory.GetComponent<open_inventory_menu>().unlock_item(3);
            chooseMenu.SetActive(false);
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            selectItems();
            chooseMenu.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            chooseMenu.SetActive(false);
            //animation_controller.SetBool("inMenu", false);
        }
    }

}
